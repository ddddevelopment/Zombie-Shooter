using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class DefaultCharacter : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    
    protected List<IFixedTick> FixedTickers = new List<IFixedTick>();
    protected List<ITick> Tickers = new List<ITick>();
    
    protected CharacterController CharacterController;

    public CharacterHealth Health { get; private set; }
    public abstract IMovement Movement { get; protected set; }

    private void Update()
    {
        foreach (var ticker in Tickers) 
        {
            ticker.Tick();
        }
    }

    private void FixedUpdate()
    {
        foreach (var fixedTicker in FixedTickers)
        {
            fixedTicker.FixedTick();
        }
    }

    public virtual void Initialize()
    {
        CharacterController = GetComponent<CharacterController>();
        Health = new CharacterHealth(_maxHealth);
    }
}