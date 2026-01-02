# UpdateFake – Simulador de Windows Update no Console

UpdateFake é um **simulador de atualização do Windows** feito em C#.  
Ele reproduz o estilo do Windows Update no CMD, com barra de progresso animada, pausa, restart e cancelamento.  
O usuário também pode definir o **tempo total da atualização** em minutos, tornando o progresso mais realista.

---

## Funcionalidades

- Barra de progresso animada, estilo CMD (`█` e `░`)
- Status dinâmico: `Downloading`, `Installing`, `Finalizing`
- Controles do usuário:
  - `P` → Pausa / Resume
  - `R` → Reiniciar download
  - `E` → Cancelar atualização
- Tempo total da atualização definido pelo usuário (em minutos)
- Mensagem final de sucesso ou cancelamento

---

## Como usar

1. Clone ou baixe o projeto.
2. Abra no Visual Studio ou VS Code com suporte C#.
3. Compile e rode o programa (`F5` ou `dotnet run`).
4. Siga as instruções no console:
   - Informe o **tempo disponível para download** (em minutos).
   - Use `P` para pausar/resumir, `R` para reiniciar e `E` para cancelar.

---

## Exemplo de execução

Microsoft Windows [Version 10.0.19045.2965]
(c) Microsoft Corporation. All rights reserved.

C:\Windows\System32>wuauclt /detectnow

Checking for updates...
1 update found.

Time available for download (minutes): 1

Downloading update 1 of 1: Cumulative Update for Windows 10 Version 21H2 (KB5006670)
Starting download...

Controls: P = Pause | R = Restart | E = Exit

Downloading [████████░░░░░░░░░░░░░░░░░░░░░░░░░░] 35%

Installing [█████████████████░░░░░░░░░░░░░░░░] 75%

Finalizing [███████████████████████████████████] 100%

Update completed successfully.
System is up to date.

Press any key to exit...

---

## Estrutura do código

- `Header()` → Exibe informações do sistema e “fake CMD”
- `Setup()` → Checa updates e solicita o tempo ao usuário
- `Run()` → Loop principal com barra de progresso, status e controles
- `Finish()` → Mensagem final (sucesso ou cancelamento)

---

## Requisitos

- .NET 6 ou superior
- Console/Terminal para execução

---

## Personalização

- Alterar **tamanho da barra**:

```csharp
const int barSize = 40; // pode aumentar ou diminuir
Alterar status fake:

csharp
Copiar código
if (progress > 70) status = "Installing";
if (progress > 90) status = "Finalizing";
Ajustar velocidade ou randomização:

int speed = random.Next(1, 4);
Thread.Sleep(totalTimeMs / total);
```
Licença
Projeto open-source para estudo e diversão.
Sinta-se à vontade para modificar e usar como quiser. 😄


