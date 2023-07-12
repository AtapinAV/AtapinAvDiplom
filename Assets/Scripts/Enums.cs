public enum States : byte
{
    idle, 
    run,
    jump,
    atk1,
    redAtk,
    skill,
    ult,
    block
}

public enum StatesDragon : byte
{
    idleDragon,
    runDragon,
    jumpDragon,
    atk1Dragon,
    ultDragon
}

public enum StatesThief : byte
{
    walk,
    atk,
    die,
    
}

public enum StatesPriest : byte
{
    idle,
    atk,
    die
}

public enum StatesSoldier : byte
{
    walk,
    atk,
    die
}

public enum StatesMerchant : byte
{
    idle,
    walk,
    hurt,
    die
}

public enum StatesDrEnemy : byte
{
    idle,
    attack,
    die
}

