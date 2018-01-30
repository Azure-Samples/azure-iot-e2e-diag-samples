## Download and setup the sample app

1. Prepare your Raspberry Pi
    ```bash
    sudo apt-get update
    sudo apt-get install -y git cmake build-essential curl libcurl4-openssl-dev libssl-dev uuid-dev
    ```

2. Clone the client application to local:

   ```bash
   git clone --recursive https://github.com/Azure/azure-iot-sdk-c-e2e-diag.git
   ```

3. Build the sdk

    ```bash
    cd azure-iot-sdk-c-e2e-diag
    mkdir cmake
    cd cmake
    cmake ..
    cmake --build .
    ```

4. Replace your device connection string

    ```bash
    vim azure-iot-sdk-c-e2e-diag/iothub_client/samples/iothub_client_sample_mqtt/iothub_client_sample_mqtt.c
    ```
    Replace the code with your device connection string:

    ```c
    static const char* connectionString = "[device connection string]";
    ```

2. Build the sample
    cd

   ```bash
   cd ./azure-iot-sdk-c/cmake/iothub_client/samples/iothub_client_sample_mqtt
   make
   ./iothub_client_sample_mqtt
   ```
