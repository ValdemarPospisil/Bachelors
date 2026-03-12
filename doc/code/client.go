package ipc

type Client interface {
	Send(command string, payload any) (string, error)
	Close() error
}
