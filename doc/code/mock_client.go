package ipc

import "github.com/stretchr/testify/mock"

type MockClient struct {
	mock.Mock
}

func (m *MockClient) Send(command string, payload any) (string, error) {
	args := m.Called(command, payload)
	return args.String(0), args.Error(1)
}

func (m *MockClient) Close() error {
	args := m.Called()
	return args.Error(0)
}
