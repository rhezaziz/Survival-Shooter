﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public PlayerShooting playerShooting;
    public PlayerMovement playerMovement;

    //Queue untuk menyimpan list command
    Queue<Command> commands = new Queue<Command>();

    private void FixedUpdate()
    {
        //Handle Input Movement
        Command moveCommand = InputMovementHandling();

        if(moveCommand != null)
        {
            commands.Enqueue(moveCommand);

            moveCommand.Execute();
        }
    }

    private void Update()
    {
        //Handle Shoot
        Command shootCommand = InputShootHandling();

        if(shootCommand != null)
            shootCommand.Execute();
    }

    Command InputMovementHandling()
    {
        //Cek jika movement sesuai key

        if (Input.GetKey(KeyCode.D))
        {
            return new MoveCommand(playerMovement, 1, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            return new MoveCommand(playerMovement, -1, 0);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            return new MoveCommand(playerMovement, 0, 1);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            return new MoveCommand(playerMovement, 0, -1);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            //Undo Movement
            return Undo();
        }
        else
        {
            return new MoveCommand(playerMovement, 0, 0);
        }
    }

    Command Undo()
    {
        //Jika Queue command tidak kosong , lakukan perintah undo
        if(commands.Count > 0)
        {
            Command undoCommand = commands.Dequeue();
            undoCommand.UnExecute();
        }
        return null;
    }

    Command InputShootHandling()
    {
        //Jika menembak trigger shoot command
        if (Input.GetButtonDown("Fire1"))
        {
            return new ShootCommand(playerShooting);
        }
        else
        {
            return null;
        }
    }
}
