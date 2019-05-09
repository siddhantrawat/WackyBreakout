using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public static class EventManager {

    //for effects
    static PickUpBlock invoker;
    static UnityAction<int> freezerListners;
    static List<UnityAction<int, int>> speedListeners = new List<UnityAction<int, int>>();

    //for score update
    static List<Block> blockInvoker = new List<Block>();
    static UnityAction<int> updateScoreListners;

    //for reducing ball count
    static Ball ballInvoker;
    static UnityAction reduceBallListners;

    //for ball spawn
    static Ball spawnInvoker;
    static UnityAction ballSpawnListner;

    //last ball invoker
    static HUD lastBallInvoker;
    static UnityAction lastBallListener;

    //block destory event
    static List<Block> blockDestroyInvoker = new List<Block>();
    static UnityAction blockDestroyListener;

    public static void AddInvoker(PickUpBlock script)
    {
        invoker = script;

        if (freezerListners != null)
            invoker.AddListenerToFreezer(freezerListners);
        foreach (UnityAction<int, int> item in speedListeners)
            invoker.AddListenerToSpeed(item);
    }

    public static void AddListnersToFreezer(UnityAction<int> listner)
    {
        freezerListners = listner;

        if (invoker != null)
            invoker.AddListenerToFreezer(freezerListners);
    }

    public static void AddListersToSpeed(UnityAction<int, int> listener)
    {
        speedListeners.Add(listener);

        if (invoker != null) {
            foreach (UnityAction<int, int> item in speedListeners)
                invoker.AddListenerToSpeed(item);
        }
    }

    // for updating score

    public static void AddUpdateScoreInvoker(Block script)
    {
        blockInvoker.Add(script);

        if (updateScoreListners != null)
            foreach (Block entry in blockInvoker)
                entry.AddUpdateScoreListener(updateScoreListners);
    }

    public static void AddUpdateScoreListener(UnityAction<int> listner)
    {
        updateScoreListners = listner;
        foreach (Block entry in blockInvoker)
            entry.AddUpdateScoreListener(updateScoreListners);
    }

    public static void AddBallInvoker(Ball script)
    {
        ballInvoker = script;
        if (reduceBallListners != null)
        {
            ballInvoker.AddReduceBallListener(reduceBallListners);
        }
    }

    public static void AddReduceBallListener(UnityAction listener)
    {
        reduceBallListners = listener;
        if (ballInvoker != null)
        {
            ballInvoker.AddReduceBallListener(listener);
        }

    }

    public static void AddSpawnInvoker(Ball invoker)
    {
        spawnInvoker = invoker;
        if (ballSpawnListner != null)
        {
            spawnInvoker.AddSpawnListener(ballSpawnListner);
        }
    }

   
    public static void AddBallSpawnListener(UnityAction listener)
    {
        ballSpawnListner = listener;
        
        if(spawnInvoker!=null)
        {
            spawnInvoker.AddSpawnListener(listener);
        }
    }
    public static void AddLastBallInvoker(HUD invoker)
    {
        lastBallInvoker = invoker;

        if (lastBallListener != null)
        {
            lastBallInvoker.AddLastBallListener(lastBallListener);
        }
    }

    public static void AddLastBallListener(UnityAction listener)
    {
        lastBallListener = listener;
        if (lastBallInvoker != null)
        {
            lastBallInvoker.AddLastBallListener(listener);
        }
    }

    public static void AddBlockDestroyInvoker(Block invoker)
    {
        blockDestroyInvoker.Add(invoker);

        if (blockDestroyListener != null)
        {
            foreach (Block entry in blockDestroyInvoker)
                entry.AddBlockDestroyListener(blockDestroyListener);
        }    
    }

    public static void AddBlockDestroyListerner(UnityAction listener)
    {
        blockDestroyListener = listener;
        
            foreach (Block entry in blockDestroyInvoker)
                entry.AddBlockDestroyListener(listener);

    }
}