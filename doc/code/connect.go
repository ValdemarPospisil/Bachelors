package cmd

import (
	"fmt"
	"strings"

	"ga-cli/internal/ipc"
	"ga-cli/internal/tui/connect"

	tea "github.com/charmbracelet/bubbletea"
	"github.com/spf13/cobra"
)

func NewConnectCmd(client ipc.Client) *cobra.Command {
	var protocol string
	var gateway bool

	cmd := &cobra.Command{
		Use:   "connect",
		Short: "Connect to the VPN",
		Long:  `Establishes a VPN connection to the default or specified gateway.`,
		RunE: func(cmd *cobra.Command, args []string) error {
			protoLower := strings.ToLower(protocol)
			if protoLower != "wireguard" && protoLower != "openvpn" {
				fmt.Println("Unknown protocol, defaulting to WireGuard")
				protocol = "WireGuard"
			} else {
				if protoLower == "wireguard" {
					protocol = "WireGuard"
				}
				if protoLower == "openvpn" {
					protocol = "OpenVPN"
				}
			}

			p := tea.NewProgram(connect.New(client, protocol, gateway))
			if _, err := p.Run(); err != nil {
				return fmt.Errorf("error running connect: %w", err)
			}

			return nil
		},
	}

	cmd.Flags().StringVarP(&protocol, "protocol", "p", "WireGuard", "VPN protocol (wireguard/openvpn)")
	cmd.Flags().BoolVarP(&gateway, "gateway", "g", false, "Select gateway from a list")

	return cmd
}
