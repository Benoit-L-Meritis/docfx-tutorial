param(
    [Parameter(Mandatory=$true)]
    [string]$RootPath
)

function Create-TocFile {
    param(
        [string]$DirectoryPath
    )
    
    Write-Host "Traitement du dossier: $DirectoryPath"
    
    # Chemin du fichier toc.yml à créer
    $tocFilePath = Join-Path $DirectoryPath "toc.yml"
    
    # Initialiser le contenu du fichier TOC
    $tocContent = @()
    
    # Récupérer tous les fichiers .md dans le dossier courant (pas récursif)
    $mdFiles = Get-ChildItem -Path $DirectoryPath -Filter "*.md" -File | Sort-Object Name
    
    # Ajouter les fichiers .md au TOC
    foreach ($file in $mdFiles) {
        $nameWithoutExtension = [System.IO.Path]::GetFileNameWithoutExtension($file.Name)
        $tocContent += "- name: $nameWithoutExtension"
        $tocContent += "  href: $($file.Name)"
    }
    
    # Récupérer tous les sous-dossiers
    $subDirectories = Get-ChildItem -Path $DirectoryPath -Directory | Sort-Object Name
    
    # Ajouter les sous-dossiers au TOC
    foreach ($subDir in $subDirectories) {
        $tocContent += "- name: $($subDir.Name)"
        $tocContent += "  href: $($subDir.Name)/toc.yml"
    }
    
    # Écrire le fichier toc.yml (écrase s'il existe déjà)
    if ($tocContent.Count -gt 0) {
        $tocContent | Out-File -FilePath $tocFilePath -Encoding UTF8 -Force
        Write-Host "Fichier créé: $tocFilePath"
    } else {
        Write-Host "Aucun contenu à écrire dans: $DirectoryPath"
    }
}

function Process-DirectoryRecursive {
    param(
        [string]$DirectoryPath
    )
    
    # Traiter d'abord tous les sous-dossiers (récursion)
    $subDirectories = Get-ChildItem -Path $DirectoryPath -Directory
    
    foreach ($subDir in $subDirectories) {
        Process-DirectoryRecursive -DirectoryPath $subDir.FullName
    }
    
    # Puis traiter le dossier courant
    Create-TocFile -DirectoryPath $DirectoryPath
}

# Vérifier que le chemin existe
if (-not (Test-Path $RootPath)) {
    Write-Error "Le chemin spécifié n'existe pas: $RootPath"
    exit 1
}

# Vérifier que c'est bien un dossier
if (-not (Test-Path $RootPath -PathType Container)) {
    Write-Error "Le chemin spécifié n'est pas un dossier: $RootPath"
    exit 1
}

Write-Host "Début du traitement récursif à partir de: $RootPath"
Write-Host "----------------------------------------"

# Lancer le traitement récursif
Process-DirectoryRecursive -DirectoryPath $RootPath

Write-Host "----------------------------------------"
Write-Host "Traitement terminé!"