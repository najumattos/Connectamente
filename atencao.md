**Os passos 01 e 02 servem para voce configurar o projeto no seu github**
* o Passo 01 é para o projeto aparecer na lista de repositorios do seu perfil
* o Passo 02 é para definir que a frontend é a branch padrao para que toda vez que voce fizer pull ou push automaticamente va para essa branch


### 01. FORK 

```bash 
Acesse: https://github.com/najumattos/Connectamente/fork
```

*   DESATIVAR Copy the ```backend``` branch only



### 02. SWITCH BRANCH
```bash
Acesse: https://github.com/tainara-vitsantos/Connectamente/settings
```
* Default branch -> switch to another branch -> Mude para ```frontend```

#


A partir de agora é só fazer clone, pull push normalmente, a configuração acima só é necessária uma vez.

**Agora Toda vez que vocês for mexer no projeto voce vai abrir sempre dois terminais no VScode**
```bash
cd Connectamente.API -> dotnet watch run
```
```bash
cd Connectamente.Interface -> npm install -> npm run dev
```

### FRONTEND Próximos Passos

Estilizar as seguintes páginas:
```bash
* Coordenador/GestaoPsicologos/index            -Pode chamar FormUsuarioComponent
* Coordenador/GestaoPacientes/index             -Pode chamar FormUsuarioComponent
* Coordenador/GestaoPacientes/Visualizar        -Pode chamar DetalhesPacienteComponent
* Coordenador/GestaoPsicologos/Visualizar       -Para padronizar, pode chamar DetalhesPsicologoComponent

* Aluno/MeusPacientes/index                     -Pode chamar FormUsuarioComponent
* Aluno/MeusPacientes/Visualizar                -Pode chamar DetalhesPacienteComponent
```

Acessar Trello
```
https://trello.com/invite/b/69d02d365f7f27c8456310fb/ATTIf18109fdb7a7f58ae3811bc7c0b1bfcdA03C5932/connectagrantiete
```
