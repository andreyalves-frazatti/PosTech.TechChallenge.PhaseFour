# PosTech.TechChallenge.PhaseFour

## Introdução

Esse projeto tem como objetivo demonstrar a utilização de todos os conhecimentos adquiridos durante a **Fase 4** na Pós Graduação da FIAP em **Desenvolvimento .NET e Azure**.

## Requisitos

O Tech Challenge desta fase será a demonstração da utilização do **RabbitMq**. Os requisitos são:

- Um producer, que deve enviar os dados para um Broker (RabbitMQ ou ServiceBus).
- Um consumer, que deve ler esses dados e processá-los.

## Resolução

**Cenário**: Uma API simples que possui uma rota para criação de mensagens.

O objetivo era explorar um cenário onde ao invés da API processar os dados recebidos, ela apenas publicasse no Broker e assim responder mais rápido as requisições HTTP.
