using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perseguicao : MonoBehaviour
{
    
    public Transform jogador; // Referência ao objeto do jogador
    public Transform limiteEsquerda; // Limite esquerdo da área de perseguição
    public Transform limiteDireita; // Limite direito da área de perseguição
    public float velocidadePerseguicao = 2.0f; // Velocidade de movimento durante a perseguição
    public float velocidadePatrulha = 5.0f; // Velocidade de movimento durante a patrulha
    private Vector3 posicaoInicial; // Armazena a posição inicial

    private bool perseguindo = false; // Flag para indicar se o inimigo está perseguindo

    void Start()
    {
        posicaoInicial = transform.position; // Armazena a posição inicial
    }

    void Update()
    {
        // Calcula a distância entre o inimigo e o jogador
        float distanciaJogador = Vector3.Distance(transform.position, jogador.position);

        if (distanciaJogador < 10.0f)
        {
            perseguindo = true; // Inicia a perseguição se o jogador estiver perto o suficiente
        }

        if (perseguindo)
        {
            // Persegue o jogador
            Vector3 direcao = jogador.position - transform.position;
            direcao.Normalize();
            transform.Translate(direcao * velocidadePerseguicao * Time.deltaTime);

            // Verifica se o jogador está fora do alcance e volta à posição inicial
            if (distanciaJogador > 5.0f)
            {
                perseguindo = false;
            }
        }
        else
        {
            // Retorna à posição inicial (patrulha)
            Vector3 direcaoPatrulha = posicaoInicial - transform.position;
            direcaoPatrulha.Normalize();
            transform.Translate(direcaoPatrulha * velocidadePatrulha * Time.deltaTime);

            // Verifica se chegou à posição inicial
            if (Vector3.Distance(transform.position, posicaoInicial) < 0.1f)
            {
                // Inicia a perseguição novamente
                perseguindo = true;
            }
        }

        // Limita a posição do inimigo dentro dos limites de perseguição
        float limiteEsquerdaX = limiteEsquerda.position.x;
        float limiteDireitaX = limiteDireita.position.x;

       
    }
}
