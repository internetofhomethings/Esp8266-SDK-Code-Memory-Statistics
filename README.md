<h2><strong>Esp8266-SDK-Code-Memory-Statistics</strong></h2>

This project is Windows utility used with the EspressIf SDK for ESP8266 code development.

The source code for this project is provided in the folder EspMemUsage. It was built
using the Free Microsoft Visual Studio 2015 "Community" IDE. This compiler can be
downloaded at:

https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx

Installation:

Two files are used in this project. They are in the "objects" folder:

1. EspMemUsage.exe   Add to C:\Espressif\utils folder
2. Makefile          Use this make file with your EspressIf SDK project

The following information is added to the console output when building an ESP8266 project with the SDK:

------------------------------------------------------------------------------
Resource            |Size(bytes)|    Used|       %Used|        Free|   %Free
--------------------|-----------|--------|------------|------------|----------
IRAM - Cached Code  |      32768|   30746|          94|        2022|       6
SPI  - Uncached Code|     253952|  193908|          76|       60044|      24
RAM  - Data         |      81920|   52224|          63|       29696|      37
------------------------------------------------------------------------------

This should provide a clearer picture about the memory used/available in your projects.

Hope you find this useful.




