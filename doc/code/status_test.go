package cmd

import (
	"bytes"
	"testing"

	"ga-cli/internal/ipc"

	"github.com/stretchr/testify/assert"
	"github.com/stretchr/testify/mock"
)

func TestStatus_ConnectedByOtherUser(t *testing.T) {
	mockClient := new(ipc.MockClient)
	cmd := NewStatusCmd(mockClient)
	buf := new(bytes.Buffer)
	cmd.SetOut(buf)
	cmd.SetErr(buf)

	// Mock client returning success from Send (network ok) but error in payload
	mockClient.On("Send", "status", mock.Anything).Return(`{"success": false, "error": "connected_by_other_user"}`, nil)

	err := cmd.Execute()

	// We expect nil error now as we handle it internally to avoid double printing
	assert.NoError(t, err)

	output := buf.String()
	assert.Contains(t, output, "Another user is already connected.")
	assert.Contains(t, output, "Run 'ga-cli disconnect' first.")
	assert.NotContains(t, output, "Usage:")
}
