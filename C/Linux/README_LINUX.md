## Download and setup the sample app

Add the apt repository

```bash
sudo add-apt-repository ppa:aziotsdklinux/ppa-azureiot
```

1. Prepare your environment
    ```bash
    sudo apt-get update
    sudo apt-get install -y git cmake build-essential curl libcurl4-openssl-dev libssl-dev uuid-dev azure-iot-sdk-c-dev
    ```

2. Apply private bits
    First, copy private bits to some folder
    ```bash
    tar -zxvf azure-iot-sdk-c-e2e-diag-preview-amd64.tar.gz
    sudo dpkg -i ./*.deb
    ```

3. Clone the client application to local and change to work dir

   ```bash
   git clone --recursive https://github.com/Azure-Samples/azure-iot-e2e-diag-samples.git
   cd azure-iot-e2e-diag-samples/C/Linux/linux
   ```

4. Replace your device connection string

    ```bash
    vim ../iothub_client_sample_mqtt.c
    ```
    Replace the code with your device connection string:

    ```c
    static const char* connectionString = "[device connection string]";
    ```

5. Build the sample

   ```bash
   cmake .
   cmake --build .
   ```
