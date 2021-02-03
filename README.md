# FileReaderKafkaProducer

Kafka Producer Console Application example that read in all text from file and publish to created topic using Confluent Kafka. Serilog is used to log significant producer action into file and console. 

## Demo

To be added soon.

## Installation
1. Setup Docker Compose to pull Kafka and Zookeeper images. Create a Kafka Topic using Docker CLI and Kafka Shell Script. (Link will be added soon.)

2. Download the code in this repository. 

3. To check if the message/data string published is able to be consumed. Checkout [FileReaderKafkaConsumer](https://github.com/MaybelOMW/FileReaderKafkaConsumer) !

## Framework and Packages Detail
**Framework: netcoreapp3.1** 

**NuGets:**
| Name                                      | Version       | Functionality                                                                                    |
| ----------------------------------------- |:-------------:| :------------------------------------------------------------------------------------------------|
| Autofac                                   | 6.1.0         | Dependency injection into IoC container, manage dependencies between classes.                    |
| Confluent.Kafka                           | 1.5.3         | Kafka .NET Client that provides high-level Producer and Consumer Classes and Interfaces.         |
| NewtonSoft Json.NET                       | 12.0.3        | Serializing into JSON and deserializing into .NET object.                                        |
| Serilog                                   | 2.10.0        | Provides diagnostic logging to files and console.                                                |
| Serilog.Sinks.Console                     | 3.1.1         | Writes log events to the Windows Console, supports coloring and themes.                          |
| Serilog.Sinks.File                        | 4.1.0         | Writes log events to 1 or more text files.                                                       |
| System.Configuration.ConfigurationManager | 5.0.0         | Provides types that support using configuration files, read app.setting / app.onfig.             |

## Usage
Using Visual Studio,
1. Build -> Clean Solution (This will delete all the build output files)
2. Build -> Rebuild Solution Rebuilds everything. (Try Build Solution if rebuild option unavailable)
3. Run code in Visual Studio with or without the debugger is fine.
4. Input the Kafka Topic created when the console application prompt.

## Expected Outcome
- The program will read in data string from the file path specified at App.config file.
- Data string will be published automatically.
- Published string and producer action log will be added into bin/debug/Logs/PublisherLog.txt.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## Reference link / Resources
[Autofac](https://github.com/autofac/Autofac#get-started)

[Confluent.Kafka](https://docs.confluent.io/clients-confluent-kafka-dotnet/current/index.html)

[Json.NET](https://www.newtonsoft.com/json/help/html/SerializingJSON.htm)

[Serilog](https://serilog.net/)

[Serilog.Sinks.Console](https://github.com/serilog/serilog-sinks-console#getting-started)

[Serilog.Sinks.File](https://github.com/serilog/serilog-sinks-file#getting-started)

[System.Configuration.ConfigurationManager](https://www.nuget.org/packages/system.configuration.configurationmanager/)
