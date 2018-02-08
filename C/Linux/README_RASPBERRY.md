## Download and setup the sample app

1. The sample code is only compatible with Rasberry Jessie, you can download the image [here](http://downloads.raspberrypi.org/raspbian_lite/images/raspbian_lite-2017-07-05/)

2. Append the following content into /etc/apt/source.list

```
deb http://ppa.launchpad.net/aziotsdklinux/ppa-azureiot/ubuntu vivid main
deb-src http://ppa.launchpad.net/aziotsdklinux/ppa-azureiot/ubuntu vivid main

deb http://ppa.launchpad.net/aziotsdklinux/ppa-azureiot/ubuntu jessie main
deb-src http://ppa.launchpad.net/aziotsdklinux/ppa-azureiot/ubuntu jessie main
```

3. Prepare your environment
    ```bash
    sudo apt-get update
    sudo apt-get install -y git cmake build-essential curl libcurl4-openssl-dev libssl-dev uuid-dev azure-iot-sdk-c-dev
    ```

4. Apply private bits
    First, copy private bits to some folder
    ```bash
    tar -zxvf azure-iot-sdk-c-0.1.0.38.jessie_armhf.tar.gz
    sudo dpkg -i ./*.deb
    ```

5. Clone the client application to local and change to work dir

   ```bash
   git clone --recursive https://github.com/Azure-Samples/azure-iot-e2e-diag-samples.git
   cd azure-iot-e2e-diag-samples/C/Linux/linux
   ```

6. Replace your device connection string

    ```bash
    vim ../iothub_client_sample_mqtt.c
    ```
    Replace the code with your device connection string:

    ```c
    static const char* connectionString = "[device connection string]";
    ```

7. Build the sample

   ```bash
   cmake .
   cmake --build .
   ```
