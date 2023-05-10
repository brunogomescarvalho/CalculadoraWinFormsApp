namespace CalculadoraClassLib;

public abstract class Operacao
{
    protected decimal Numero01 { get; set; }
    protected decimal Numero02 { get; set; }

    public Operacao(decimal nr1, decimal nr2)
    {
        Numero01 = nr1;
        Numero02 = nr2;
    }
    public abstract decimal Calcular();
}


public class Adicao : Operacao
{
    public Adicao(decimal nr1, decimal nr2) : base(nr1, nr2){ }
    public override decimal Calcular()
    {
        return Numero01 + Numero02;
    }
}

public class Subtracao : Operacao
{
    public Subtracao(decimal nr1, decimal nr2) : base(nr1, nr2){ }
    public override decimal Calcular()
    {
        return Numero01 - Numero02;
    }
}

public class Divisao : Operacao
{
    public Divisao(decimal nr1, decimal nr2) : base(nr1, nr2) { }
  
    public override decimal Calcular()
    {
        return Numero01 / Numero02;
    }
}

public class Multiplicacao : Operacao
{
    public Multiplicacao(decimal nr1, decimal nr2) : base(nr1, nr2) { }
  
    public override decimal Calcular()
    {
        return Numero01 * Numero02;
    }
}
