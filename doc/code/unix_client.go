package adapter

import (
	"bufio"
	"encoding/json"
	"fmt"
	"net"
	"os"
	"strconv"
	"strings"
	"time"

	"ga-cli/internal/ipc"
)

type UnixClient struct {
	socketPath string
	timeout    time.Duration
}

func NewUnixClient(path string) *UnixClient {
	return &UnixClient{
		socketPath: path,
		timeout:    60 * time.Second,
	}
}

func getRealUserUID() string {
	uid := os.Getuid()

	if uid == 0 {
		sudoUidStr := os.Getenv("SUDO_UID")
		if sudoUidStr != "" {
			return sudoUidStr
		}
	}

	return strconv.Itoa(uid)
}

func (c *UnixClient) Send(command string, payload any) (string, error) {
	IsRoot := os.Getuid() == 0  
	conn, err := net.DialTimeout("unix", c.socketPath, c.timeout)
	if err != nil {
		return "", fmt.Errorf("connection failed: %w", err)
	}
	defer func() { _ = conn.Close() }()

	if err := conn.SetDeadline(time.Now().Add(c.timeout)); err != nil {
		return "", fmt.Errorf("failed to set deadline: %w", err)
	}

	req := ipc.RequestEnvelope{
		Command: command,
		Payload: payload,
		Context: &ipc.RequestContext{
			LinuxId: getRealUserUID(),
			IsRoot: IsRoot, 
		},
	}

	jsonBytes, err := json.Marshal(req)
	if err != nil {
		return "", fmt.Errorf("marshaling failed: %w", err)
	}

	_, err = fmt.Fprintf(conn, "%s\n", string(jsonBytes))
	if err != nil {
		return "", fmt.Errorf("send failed: %w", err)
	}

	reader := bufio.NewReader(conn)
	responseLine, err := reader.ReadString('\n')
	if err != nil {
		return "", fmt.Errorf("read failed: %w", err)
	}

	return strings.TrimSpace(responseLine), nil
}

func (c *UnixClient) Close() error {
	return nil
}
