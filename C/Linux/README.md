## Download and setup the sample app

Append the following content into /etc/apt/source.list
??vivid or jessie??

```
deb http://ppa.launchpad.net/aziotsdklinux/ppa-azureiot/ubuntu vivid main
deb-src http://ppa.launchpad.net/aziotsdklinux/ppa-azureiot/ubuntu vivid main

deb http://ppa.launchpad.net/aziotsdklinux/ppa-azureiot/ubuntu jessie main
deb-src http://ppa.launchpad.net/aziotsdklinux/ppa-azureiot/ubuntu jessie main
```

1. Prepare your Raspberry Pi
    ```bash
    sudo apt-get update
    sudo apt-get install -y git cmake build-essential curl libcurl4-openssl-dev libssl-dev uuid-dev azure-iot-sdk-c-dev
    ```

2. Clone the client application to local and change to work dir

   ```bash
   git clone --recursive https://github.com/Azure-Samples/azure-iot-e2e-diag-samples.git
   cd azure-iot-e2e-diag-samples/C/Linux/linux
   ```

Replace with preview bits
 
For Linux AMD64
??
```bash
sudo dpkg -i ./.deb
```
For Raspberry Pi
```
sudo dpkg -i ./.deb
```

4. Replace your device connection string

    ```bash
    vim ../iothub_client_sample_mqtt.c
    ```
    Replace the code with your device connection string:

    ```c
    static const char* connectionString = "[device connection string]";
    ```

2. Build the sample
    cd

   ```bash
   cmake .
   cmake --build .
   ```
