﻿using CommandSystem;
using PixelSpray;
using PixelSpray.Commands.SprayCommands;
using System;

namespace Callvote.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class CallVoteCommand : ParentCommand
    {
        public override string Command => "pixelspray";

        public override string[] Aliases => new[] { "ps" };

        public override string Description => PixelSprayPlugin.Instance.Translation.SprayCommandDescription;

        public CallVoteCommand() => LoadGeneratedCommands();

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new SprayCommand());
            RegisterCommand(new RemoveSprayCommand());
            RegisterCommand(new ListSprayCommand());
            RegisterCommand(new RespraySprayCommand());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = PixelSprayPlugin.Instance.Translation.Usage;
            return false;
        }
    }
}