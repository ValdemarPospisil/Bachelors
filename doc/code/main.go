package main

import (
	"fmt"
	"os"

	"ga-cli/cmd"
	"ga-cli/internal/adapter"
)

func main() {

	socketPath := "/tmp/CoreFxPipe_ga-cli.sock"

	client := adapter.NewUnixClient(socketPath)

	rootCmd := cmd.NewRootCmd(client)

	if err := rootCmd.Execute(); err != nil {
		fmt.Fprintln(os.Stderr, err)

		os.Exit(1)
	}
}
