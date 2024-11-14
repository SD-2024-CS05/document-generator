# document-generator
Graphical Document Generator from Datasets

## Project Background

The student team shall utilize Microsoft DevOps (and with the guidance/assistance of the project sponsors), 1) develop a data
dictionary and 'language' describing the simple UI in verbose detail including developing a set of high level essential functions and requirements, detailed
design elements and associated meta-data, and 2) develop predefined Excel tables for supplemental definition of control, flow and behaviors written in a
somewhat pseudo-English format also with assistance of project sponsors. A simple UI and its source code (HTML 5/Canvas, N-Tier, N-Layer pattern, HTML
client, Services (C# rich), SQL) that has three pages, including a home page, with various controls and display on each page” will be provided by sponsor.

## Project Description

From these defined sets of DevOps and Excel information, the student team shall 2) interface and then integrate the DevOps and Excel
table information from the data dictionary and 'language' to 3) generate a meta-data rich graphical diagram (similar to a Visio diagram) (may be multiple
pages) that can be utilized for client discussions, initial design mockups, 30/60/90% client and technical design reviews/code walks and generation of specific
system and interface tests. 4) A simulated feedback session may then be entered back into the DevOps area and/or Excel tables, to then iterate the graphical
generation until client and review feedback suggests that iteration is no longer required for the implementation to be successful.


## How to Develop Locally

> Prior to running, a certificate must be added to the project. To get access to the certificate, please reach out to [Joshua Venable](mailto:jvenable@zagmail.gonzaga.edu)

In the `ShapeHandler` Project, add an `appsettings.json` file in the root of the project with the following content:

```json
{
  "AzureKeyVaultURI": "https://shapehandler.vault.azure.net/",
  "Neo4JURI": "<uri>",
  "Neo4JUsername": "<username>",
  "Neo4JPassword": "<password>",
  "Neo4JInstanceID": "<instance ID>",
  "Neo4JInstanceName": "ShapeHandlerDEV"
}
```
  
 
 
Set `ShapeHandler` as the startup project, and either debug or run the project.