## How to run this sample

1. Clone the client application to local:

   ```bash
   git clone https://github.com/Azure-Samples/azure-iot-e2e-diag-samples.git
   ```

3. Replace your device connection string

    ```bash
    cd azure-iot-e2e-diag-samples\C\SimulatedDevice
    ```
    Replace your device connection string in .\iothub_client_sample_mqtt.c

4. Use local nuget package

    1) Open the project using VS2015
    2) [Install the local Nuget Package](https://stackoverflow.com/questions/10240029/how-do-i-install-a-nuget-package-nupkg-file-locally) and put preview bits you downloaded and unzipped into the local nuget folder.

5. Build and run the application

   Click start button to build and run the application
