# Générer la documentation OPEN API JSON en .Net Minimal API

## Configuration

Pour ce projet, j'ai fait le choix de ne pas exposer le fichier open API sur le serveur en mode développement
mais au build du projet.

Pour cela, j'indique dans le `Program.cs` que j'utilise OpenAPI

```cs
builder.Services.AddOpenApi();

// Ici en commentaire pour le tuto, mais sinon à enlever
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
}
```

Et je passe par le fichier `.csproj` pour la configuration de la génération du json de la doc Open API

```xml
  <PropertyGroup>
    <OpenApiDocumentsDirectory>.</OpenApiDocumentsDirectory>
    <OpenApiGenerateDocumentsOptions>--openapi-version OpenApi2_0</OpenApiGenerateDocumentsOptions>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
  </PropertyGroup>
```

*Nb : On force la version 2.0 car DocFX ne supporte pas encore la version 3.0*

Et je m'assure que le fichier n'est pas copié dans la sortie

```xml
  <ItemGroup>
    <None Update="MinimalApiSample.json">
      <CopyToOutputDirectory>Never</CopyToOutputDirectory>
    </None>
  </ItemGroup>
```

## Pour consulter l'API

GET : [Hello World !](http://localhost:5090/hello)

GET : [Get Weather Forcast](http://localhost:5090/weatherforecast/10)
