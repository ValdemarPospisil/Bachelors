package ipc

import (
	"encoding/json"
	"fmt"
)

type RequestContext struct {
	LinuxId string `json:"LinuxId"`
	IsRoot  bool   `json:"IsRoot"`
}

type RequestEnvelope struct {
	Command string          `json:"command"`
	Payload any             `json:"payload,omitempty"`
	Context *RequestContext `json:"context,omitempty"`
}

type ResponseEnvelope[T any] struct {
	Success bool   `json:"success"`
	Data    T      `json:"data"`
	Error   string `json:"error,omitempty"`
}

func Unpack[T any](rawJSON string) (*T, error) {
	var envelope ResponseEnvelope[T]

	if err := json.Unmarshal([]byte(rawJSON), &envelope); err != nil {
		return nil, fmt.Errorf("failed to parse response: %w", err)
	}

	if !envelope.Success {
		return nil, fmt.Errorf("%s", envelope.Error)
	}

	return &envelope.Data, nil
}
