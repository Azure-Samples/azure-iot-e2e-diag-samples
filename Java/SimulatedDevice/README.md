## How to run this sample

1. Prepare your PC

    [Install latest Java SE Development Kit 8](http://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html)

    [Install Maven 3](https://maven.apache.org/install.html)

2. Clone the client application to local:

   ```bash
   git clone https://github.com/Azure-Samples/azure-iot-e2e-diag-samples.git
   ```

3. Replace your device connection string

    ```bash
    cd azure-iot-e2e-diag-samples\Java\SimulatedDevice
    ```
    Replace variables connString and deviceId with real values in .\src\main\java\com\mycompany\app\App.java

4. Build and run the sample (On Windows platform please use CMD to execute commands)

   ```bash
    mvn clean package -DskipTests
    mvn exec:java -Dexec.mainClass="com.mycompany.app.App"
   ```
