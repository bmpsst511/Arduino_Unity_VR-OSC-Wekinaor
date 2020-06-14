#include <Arduino.h>

/** WIFI LIBRARY PART**/
#include <ESP8266WiFi.h>
#include <WiFiClient.h>
//#include <WiFiUDP.h>
/** WIFI LIBRARY PART**/

#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>
#include <utility/imumaths.h>

#include <WiFiUDP.h>
#include <OSCMessage.h>

/** WIFI分享器設定 **/
//const char* ssid ="TP-LINK_A7366A";
//const char* pass = "03487150";
const char* ssid ="Jphone";
const char* pass = "nethika609";
const IPAddress outIp(172,20,10,6);
const unsigned int outPort = 6448;
const unsigned int localPort = 6969;
WiFiUDP Udp;
WiFiServer server(outPort);
/** WIFI分享器設定 **/

String RotateX, RotateY, RotateZ, AccelX, AccelY, AccelZ;

/* Set the delay between fresh samples */
#define BNO055_SAMPLERATE_DELAY_MS (100)

Adafruit_BNO055 bno = Adafruit_BNO055(55);


/**************************************************************************/
/*
    Displays some basic information on this sensor from the unified
    sensor API sensor_t type (see Adafruit_Sensor for more information)
*/
/**************************************************************************/

void displaySensorDetails(void)
{
  sensor_t sensor;
  bno.getSensor(&sensor);
  Serial.println("------------------------------------");
  Serial.print  ("Sensor:       "); Serial.println(sensor.name);
  Serial.print  ("Driver Ver:   "); Serial.println(sensor.version);
  Serial.print  ("Unique ID:    "); Serial.println(sensor.sensor_id);
  Serial.print  ("Max Value:    "); Serial.print(sensor.max_value); Serial.println(" xxx");
  Serial.print  ("Min Value:    "); Serial.print(sensor.min_value); Serial.println(" xxx");
  Serial.print  ("Resolution:   "); Serial.print(sensor.resolution); Serial.println(" xxx"); 
  Serial.println("------------------------------------");
  Serial.println("");
  delay(500);
}
 
void setup() {
  Serial.begin(9600);
  
  /** 上電後執行WIFI連線與顯示相關資訊**/
      // Connect to WiFi network
    Serial.println();
    Serial.println();
    Serial.print("Connecting to ");
    Serial.println(ssid);
    WiFi.begin(ssid, pass);

    while (WiFi.status() != WL_CONNECTED) {
        delay(500);
        Serial.print(".");
    }
    Serial.println("");

    Serial.println("WiFi connected");
    Serial.println("IP address: ");
    Serial.println(WiFi.localIP());

    Serial.println("Starting UDP");
    Udp.begin(localPort);
    Serial.print("Local port: ");
#ifdef ESP32
    Serial.println(localPort);
#else
    Serial.println(Udp.localPort());
#endif
  /** 上電後執行WIFI連線與顯示相關資訊**/
  
   /* Initialise the sensor */
  if(!bno.begin())
  {
    /* There was a problem detecting the BNO055 ... check your connections */
    Serial.print("Ooops, no BNO055 detected ... Check your wiring or I2C ADDR!");
    while(1);
  }

    /* Use external crystal for better accuracy */
  bno.setExtCrystalUse(true);
   
  /* Display some basic information on this sensor */
  displaySensorDetails();
  
}
 
void loop() {

/*Get a new sensor event */
  sensors_event_t event;
  bno.getEvent(&event);
  imu::Vector<3> euler = bno.getVector(Adafruit_BNO055::VECTOR_EULER);
  imu::Vector<3> acceler = bno.getVector(Adafruit_BNO055::VECTOR_ACCELEROMETER);
  /* Board layout:
         +----------+
         |         *| RST   PITCH  ROLL  HEADING
     ADR |*        *| SCL
     INT |*        *| SDA     ^            /->
     PS1 |*        *| GND     |            |
     PS0 |*        *| 3VO     Y    Z-->    \-X
         |         *| VIN
         +----------+
  */

  /* The processing sketch expects data as roll, pitch, heading */

  /*Serial.print((int)euler.x());//Serial.print(";");
  Serial.print(F(" "));
  Serial.print((int)euler.y());//Serial.print(";");
  Serial.print(F(" "));
  Serial.print((int)euler.z());//Serial.print(";");
  Serial.print(F(" "));
  Serial.print((int)acceler.x());//Serial.print(";");
  Serial.print(F(" "));
  Serial.print((int)acceler.y());//Serial.print(";");
  Serial.print(F(" "));
  Serial.print((int)acceler.z());//Serial.print("\t");
  */
  RotateX = (int)euler.x(); //yaw
  RotateY = (int)euler.y(); //pitch
  RotateZ = (int)euler.z(); //roll

  AccelX = (int)acceler.x();
  AccelY = (int)acceler.y();
  AccelZ = (int)acceler.z();

  /* Also send calibration data for each sensor. */
  uint8_t sys, gyro, accel, mag = 3;
  bno.getCalibration(&sys, &gyro, &accel, &mag);
 /* Serial.print(F("Calibration: "));
  Serial.print(sys, DEC);
  Serial.print(F(" "));
  Serial.print(gyro, DEC);
  Serial.print(F(" "));
  Serial.print(accel, DEC);
  Serial.print(F(" "));
  Serial.println(mag, DEC);*/
  //Serial.print("\r\n");
  Serial.print((int)euler.x(), DEC); 
  Serial.print(",");
  Serial.print((int)euler.y(), DEC); 
  Serial.println();
  
  /**開始發送資料給Server端 **/
    OSCMessage msg("/wek/inputs");
    msg.add((float)euler.x());
    msg.add((float)euler.y());
    msg.add((float)euler.z());
    Udp.beginPacket(outIp, outPort);
    msg.send(Udp);
    Udp.endPacket();
    //msg.empty();
    //delay(500);
    delay(BNO055_SAMPLERATE_DELAY_MS);
  /**開始發送資料給Server端 **/

}
 
