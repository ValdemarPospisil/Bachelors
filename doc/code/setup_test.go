package setup

import (
	"encoding/json"
	"testing"

	"ga-cli/internal/ipc"
	"ga-cli/internal/model"
	"ga-cli/internal/tui/login"

	tea "github.com/charmbracelet/bubbletea"
	"github.com/stretchr/testify/assert"
	"github.com/stretchr/testify/mock"
)

func TestSetup_FullFlow_NotLoggedIn(t *testing.T) {
	mockClient := new(ipc.MockClient)
	m := New(mockClient, false)

	msg := CheckLoginMsg{IsLoggedIn: false}
	updatedModel, cmd := m.Update(msg)
	m = updatedModel.(Model)

	assert.Equal(t, StepLogin, m.CurrentStep)
	assert.NotNil(t, cmd)

	updatedModel, cmd = m.Update(login.LoginSuccessMsg{})
	m = updatedModel.(Model)

	assert.Equal(t, StepProtocol, m.CurrentStep)
	assert.Nil(t, cmd)

	updatedModel, cmd = m.Update(tea.KeyMsg{Type: tea.KeyEnter})
	m = updatedModel.(Model)

	assert.Equal(t, "WireGuard", m.SelectedProtocol)
	assert.Equal(t, StepFetchGateways, m.CurrentStep)
	assert.NotNil(t, cmd)

	gateways := []model.GatewayResponse{
		{ID: "g1", Name: "Gateway 1", CountryCode: "US", IP: "1.2.3.4"},
	}
	gatewaysBytes, _ := json.Marshal(ipc.ResponseEnvelope[[]model.GatewayResponse]{Success: true, Data: gateways})
	mockClient.On("Send", "get_gateways", mock.Anything).Return(string(gatewaysBytes), nil)

	gwMsg := cmd()
	assert.IsType(t, gatewaysLoadedMsg{}, gwMsg)

	updatedModel, cmd = m.Update(gwMsg)
	m = updatedModel.(Model)

	assert.Equal(t, StepGateway, m.CurrentStep)
	assert.Equal(t, gateways, m.AvailableGateways)
	assert.Nil(t, cmd)

	updatedModel, cmd = m.Update(tea.KeyMsg{Type: tea.KeyEnter})
	m = updatedModel.(Model)

	assert.Equal(t, gateways[0], m.SelectedGateway)
	assert.Equal(t, StepPersistent, m.CurrentStep)
	assert.Nil(t, cmd)

	updatedModel, cmd = m.Update(tea.KeyMsg{Type: tea.KeyEnter})
	m = updatedModel.(Model)

	assert.True(t, m.IsPersistent)
	assert.Equal(t, StepSaving, m.CurrentStep)
	assert.NotNil(t, cmd)

	expectedPayload := model.SaveConfigPayload{
		GatewayID:          "g1",
		GatewayName:        "Gateway 1",
		GatewayIP:          "1.2.3.4",
		GatewayCountryCode: "US",
		Protocol:           "WireGuard",
		Persistent:         true,
	}

	mockClient.On("Send", "save_config", mock.MatchedBy(func(p model.SaveConfigPayload) bool {
		return p == expectedPayload
	})).Return(`{"success": true}`, nil)

	saveMsg := cmd()
	assert.IsType(t, configSavedMsg{}, saveMsg)

	updatedModel, cmd = m.Update(saveMsg)
	m = updatedModel.(Model)

	assert.Equal(t, StepConnect, m.CurrentStep)
	assert.Nil(t, cmd)

	updatedModel, _ = m.Update(tea.KeyMsg{Type: tea.KeyDown})
	m = updatedModel.(Model)
	updatedModel, cmd = m.Update(tea.KeyMsg{Type: tea.KeyEnter})
	m = updatedModel.(Model)

	assert.Equal(t, StepSuccess, m.CurrentStep)
	assert.NotNil(t, cmd)
	assert.IsType(t, tea.QuitMsg{}, cmd())

	mockClient.AssertExpectations(t)
}

func TestSetup_AlreadyLoggedIn(t *testing.T) {
	mockClient := new(ipc.MockClient)
	m := New(mockClient, false)

	msg := CheckLoginMsg{IsLoggedIn: true, UserName: "test@user.com"}
	updatedModel, cmd := m.Update(msg)
	m = updatedModel.(Model)

	assert.Equal(t, StepProtocol, m.CurrentStep)
	assert.Equal(t, "test@user.com", m.UserName)
	assert.Nil(t, cmd)
}

func TestSetup_AlreadyConnected(t *testing.T) {
	mockClient := new(ipc.MockClient)
	m := New(mockClient, false)

	msg := CheckLoginMsg{IsLoggedIn: true, IsConnected: true, UserName: "test@user.com"}
	updatedModel, cmd := m.Update(msg)
	m = updatedModel.(Model)

	assert.Equal(t, StepConfirmDisconnect, m.CurrentStep)
	assert.Nil(t, cmd)

	updatedModel, cmd = m.Update(tea.KeyMsg{Type: tea.KeyEnter})
	m = updatedModel.(Model)

	assert.Equal(t, StepDisconnecting, m.CurrentStep)
	assert.NotNil(t, cmd)

	mockClient.On("Send", "disconnect", mock.Anything).Return("", nil)

	discMsg := cmd()
	assert.IsType(t, DisconnectSuccessMsg(""), discMsg)

	updatedModel, cmd = m.Update(discMsg)
	m = updatedModel.(Model)

	assert.Equal(t, StepProtocol, m.CurrentStep)
	assert.Nil(t, cmd)
}

func TestSetup_AnotherUserConnected(t *testing.T) {
	mockClient := new(ipc.MockClient)
	m := New(mockClient, false)

	// Mock check_state returning IsAnotherUserConnected: true
	mockClient.On("Send", "check_state", mock.Anything).Return(`{"success": true, "data": {"IsLoggedIn": true, "IsConnected": false, "UserName": "testuser", "IsAnotherUserConnected": true}}`, nil)

	// We need to access the unexported checkLoginStatusCmd to test it directly,
	// or we can test via Init() which calls it.
	// Since checkLoginStatusCmd is unexported in the same package, we can call it in test.
	cmd := checkLoginStatusCmd(mockClient)
	msg := cmd()

	assert.IsType(t, CheckLoginMsg{}, msg)
	clMsg := msg.(CheckLoginMsg)
	assert.True(t, clMsg.IsAnotherUserConnected)

	// Simulate Update with CheckLoginMsg
	var updatedModel tea.Model
	updatedModel, cmd = m.Update(clMsg)
	m = updatedModel.(Model)

	// Should set error and quit
	assert.Error(t, m.err)
	assert.Equal(t, "connected_by_other_user", m.err.Error())
	assert.NotNil(t, cmd)
	assert.IsType(t, tea.QuitMsg{}, cmd())

	mockClient.AssertExpectations(t)
}
