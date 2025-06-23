# DocFX Tutorial

## Installation

Vérifier la version de DocFX sur votre machine

```shell
dotnet tool update -g docfx
```

## Ajouter DocFX à votre projet

Préparer la structure des dossiers dans votre projet pour faciliter le suivi du versionning de la documentation.

Initier un projet DocFX dans votre dossier existant avec la ligne de commande

```shell
docfx init
```

Répondre aux différentes questions

<!--- attention pour les sources src de bien prendre dofx-tutorial/src -->

## Ajouter les tables des matières

Docfx se base sur des fichiers YAML pour les tables des matières (TOC) `toc.yml`

Utilisation d'un scripts pwsh pour automatiser cela.

## Générer le site et le servir en local

Servir le site en local

```shell
docfx docfx.json --serve
```

Si MAJ du code source, appliquer la commande

```shell
docfx docfx.json
```

## Customiser la barre de liens

En dehors des entrées ajoutées automatiquement, vous pouvez ajouter des entrées dans la barre de liens.

Pour cela, éditer le fichier `toc.yml` à la racine du projet

Exemple

```yml
- name: Documentation
  href: docs/
- name: Visitor Pattern
  href: src/VisitorPattern/Visitor/README.md
- name: Weather Forecast API
  href: src/MinimalApiSample\MinimalApiSample.html
- name: NDoc
  href: api/
```

## Customiser la page d'accueil

Il est possible de mettre en forme la page d'accueil en éditant le fichier `index.md` à la racide du projet.

---

## Déploiement via un pipeline

On peut intégrer cela à un pipeline et déployer sur GitHub Pages, ex :

```yml
# Your GitHub workflow file under .github/workflows/
# Trigger the action on push to main
on:
  push:
    branches:
      - main

# Sets permissions of the GITHUB_TOKEN to allow deployment to GitHub Pages
permissions:
  actions: read
  pages: write
  id-token: write

# Allow only one concurrent deployment, skipping runs queued between the run in-progress and latest queued.
# However, do NOT cancel in-progress runs as we want to allow these production deployments to complete.
concurrency:
  group: "pages"
  cancel-in-progress: false
  
jobs:
  publish-docs:
    environment:
      name: github-pages
      url: ${{ steps.deployment.outputs.page_url }}
    runs-on: ubuntu-latest
    steps:
    - name: Checkout
      uses: actions/checkout@v3
    - name: Dotnet Setup
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 8.x

    - run: dotnet tool update -g docfx
    - run: docfx <docfx-project-path>/docfx.json

    - name: Upload artifact
      uses: actions/upload-pages-artifact@v3
      with:
        # Upload entire repository
        path: '<docfx-project-path>/_site'
    - name: Deploy to GitHub Pages
      id: deployment
      uses: actions/deploy-pages@v4
```
