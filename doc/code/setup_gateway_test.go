package setup

import (
	"encoding/json"
	"testing"

	"ga-cli/internal/ipc"
	"ga-cli/internal/model"

	tea "github.com/charmbracelet/bubbletea"
	"github.com/stretchr/testify/assert"
	"github.com/stretchr/testify/mock"
)

func TestSetup_GatewayOnly(t *testing.T) {
	mockClient := new(ipc.MockClient)
	m := New(mockClient, true)

	msg := CheckLoginMsg{IsLoggedIn: true, UserName: "test@user.com"}
	updatedModel, cmd := m.Update(msg)
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
	updatedModel, _ = m.Update(gwMsg)
	m = updatedModel.(Model)

	assert.Equal(t, StepGateway, m.CurrentStep)

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
	updatedModel, _ = m.Update(saveMsg)
	m = updatedModel.(Model)

	assert.Equal(t, StepConnect, m.CurrentStep)
}
