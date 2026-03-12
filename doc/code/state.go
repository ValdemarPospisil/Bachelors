package service 

import (
	"ga-cli/internal/ipc"
	"ga-cli/internal/model"
)

func GetAppState(client ipc.Client) (*model.AppStateResponse, error) {
	resp, err := client.Send("check_state", nil)
	if err != nil {
		return nil, err
	}

	return ipc.Unpack[model.AppStateResponse](resp)
}
