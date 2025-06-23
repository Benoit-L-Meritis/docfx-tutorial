# Exemple d'ADR

- Date : 2022/01/11
- Décision prise par : Product Owner, Développeurs

## Contexte
Les objets métiers ont un nom français, mais l’équipe de run sera anglophone.
La question est de savoir quelle langue utiliser dans notre base de code.

## Options envisagées
1. Français

    – Avantage : Nous utilisons les mêmes mots que les métiers, il est plus facile de faire des revues de code avec eux.

    – Inconvénient : L’équipe de run ne le comprend pas.

2. Anglais

    – Avantage : L’équipe d’exécution le comprendra 

    – Inconvénient : Les métiers devront traduire, et nous pourrions avoir un peu plus de réflexion à faire en codant.

## Décision
Nous choisissons l’anglais, car il est plus simple de traduire de l’anglais vers le français quand on connaît les deux langues que du français à l’anglais quand on ne connaît pas le français.

## Conséquence 
Nous décidons de mettre en place un dictionnaire de traduction avec code pour aider le processus de traduction.
