# ER - DocumentoClinico e Especializações

## Descrição
Diagrama de Entidade-Relacionamento (ER) que ilustra `DocumentoClinico` e suas 7 tabelas especializadas que herdam dela, utilizando o padrão TPT (Table-per-Type) do Entity Framework Core.

## Tabela Base
- **DOCUMENTO_CLINICO**: Classe base para todos os tipos de documentos clínicos

## Especializações (Tabelas Filhas)
1. **DOCUMENTO_IDENTIFICACAO_PACIENTE**: Dados de identificação do paciente no formulário
2. **ANAMNESE_ADULTO**: Anamnese clínica para pacientes adultos
3. **ANAMNESE_ADOLESCENTE**: Anamnese clínica para adolescentes
4. **PLANTAO_PSICOLOGICO**: Registros de plantão psicológico
5. **TERMO_PSICOTERAPIA_INDIVIDUAL**: Termo de psicoterapia individual
6. **TERMO_AUTORIZACAO_MENOR**: Autorização para atendimento de menores
7. **TERMO_COMPROMISSO_INFORMATIZACAO**: Termo de compromisso digital

## Padrão de Herança
Cada tabela especializada possui:
- `documentoClinicoId` como chave primária e estrangeira (PK,FK)
- Referência unívoca ao `DOCUMENTO_CLINICO`
- Campos específicos do tipo de documento

## Propósito
Permite armazenar diferentes tipos de documentos clínicos em tabelas separadas enquanto mantém uma tabela central de controle e rastreabilidade.
