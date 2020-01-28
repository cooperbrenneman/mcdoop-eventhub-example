# Azure Event Hub Example with .NET
This repo is meant to serve as a basic example for using Event Hubs for .NET. In this example, it sets up an Azure Event Hub and the required settings to read and write. Additionally, there are basic console applications that allow you to write and read from the Event Hub.

# Getting Started
## Configuring the Event Hub - Azure Portal
Go to the Azure Portal, and select New > Event Hubs. Create a Namespace if one is not available. Set the tier to Basic and keep the default values. Create an Event Hub with a partition count of 2 and keep the message retention of 1. Lastly create a shared access policy to allow the app to listen and send from the newly created Event Hub.

## Configuring the Event Hub - Templates
There will be an example of a file that can be used to automatically create an Azure Event Hub Namespace and an Event Hub. These files can be used to do all of the above tasks automatically instead of using the portal.

### Creating a Resource Group
Create a resource group using the below command in the Azure CLI:

```
az group create --name $resourceGroupName --location $location
```

For an example, you can create a resource group called "MyResourceGroup" in West US 2:
```
az group create --name MyResourceGroup --location "West US 2"
```

### Creating an Azure Event Hub Namespace From Templates
Once the Resource Group above is created, you can create the associated Azure Event Hub components using the below commands:
```
az group deployment create --resource-group <resourceGroupName> --template-file <path-to-template-file> --parameters @<path-to-parameters-file>
```

For this example, you can navigate to the azure-cli-files directory and execute:
```
az group deployment create --resource-group MyResourceGroup --template-file template.json --parameters @parameters.json
```

# Application Overview
The example application is a fictitious shop called "McDoops", which makes ice cream sundaes and ice cream cones. The application sends data about a specific machine, including every time a ice cream cone or sundae is made, as well as the diagnostic information (temperature and ice cream level) when requested. This data is sent to an event hub.

- McDoop.DeviceApp.ConsoleApp - Console App that is used to create a device and lets the user choose what action to take
- McDoop.EventHub.Sender - Class Library that serializes and sends device data to the event hub

## Adding the Event Hub Connection String
In order to make the McDoop.DeviceApp.ConsoleApp run successfully, the connection string for the Shared Access Policy must be copied and pasted in the `EVENTHUB_CONNECTION_STRING` of Program.cs.

# Coming Soon!
A console app that allows the events to be read from the Event Hub and displayed.