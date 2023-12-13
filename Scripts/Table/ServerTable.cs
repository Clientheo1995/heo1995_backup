using System;

public class UserCryptureData
{
    int nIndex;
    int[] arrPartIndex;
    int nR;
    int nG;
    int nB;
    bool isNFT;

    public int Index { get { return nIndex; } }
    public int[] PartsIndex { get { return arrPartIndex; } }
    public int R { get { return nR; } }
    public int G { get { return nG; } }
    public int B { get { return nB; } }
    public bool NFT { get { return isNFT; } }
}

public class Mail
{
    Guid id;
    string name;
    string text;
}