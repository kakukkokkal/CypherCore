﻿/*
 * Copyright (C) 2012-2020 CypherCore <http://github.com/CypherCore>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Framework.Constants;
using Framework.IO;
using Game.Entities;
using Game.SupportSystem;

namespace Game.Chat.Commands
{
    [CommandGroup("ticket")]
    class TicketCommands
    {
        [Command("togglesystem", RBACPermissions.CommandTicketTogglesystem, true)]
        static bool HandleToggleGMTicketSystem(CommandHandler handler)
        {
            if (!WorldConfig.GetBoolValue(WorldCfg.SupportTicketsEnabled))
            {
                handler.SendSysMessage(CypherStrings.DisallowTicketsConfig);
                return true;
            }

            bool status = !Global.SupportMgr.GetSupportSystemStatus();
            Global.SupportMgr.SetSupportSystemStatus(status);
            handler.SendSysMessage(status ? CypherStrings.AllowTickets : CypherStrings.DisallowTickets);
            return true;
        }

        [CommandGroup("bug")]
        class TicketBugCommands
        {
            [Command("assign", RBACPermissions.CommandTicketBugAssign, true)]
            static bool HandleTicketBugAssignCommand(CommandHandler handler, StringArguments args)
            {
                return HandleTicketAssignToCommand<BugTicket>(handler, args);
            }

            [Command("close", RBACPermissions.CommandTicketBugClose, true)]
            static bool HandleTicketBugCloseCommand(CommandHandler handler, StringArguments args)
            {
                return HandleCloseByIdCommand<BugTicket>(handler, args);
            }

            [Command("closedlist", RBACPermissions.CommandTicketBugClosedlist, true)]
            static bool HandleTicketBugClosedListCommand(CommandHandler handler, StringArguments args)
            {
                return HandleClosedListCommand<BugTicket>(handler, args);
            }

            [Command("comment", RBACPermissions.CommandTicketBugComment, true)]
            static bool HandleTicketBugCommentCommand(CommandHandler handler, StringArguments args)
            {
                return HandleCommentCommand<BugTicket>(handler, args);
            }

            [Command("delete", RBACPermissions.CommandTicketBugDelete, true)]
            static bool HandleTicketBugDeleteCommand(CommandHandler handler, StringArguments args)
            {
                return HandleDeleteByIdCommand<BugTicket>(handler, args);
            }

            [Command("list", RBACPermissions.CommandTicketBugList, true)]
            static bool HandleTicketBugListCommand(CommandHandler handler, StringArguments args)
            {
                return HandleListCommand<BugTicket>(handler, args);
            }

            [Command("unassign", RBACPermissions.CommandTicketBugUnassign, true)]
            static bool HandleTicketBugUnAssignCommand(CommandHandler handler, StringArguments args)
            {
                return HandleUnAssignCommand<BugTicket>(handler, args);
            }

            [Command("view", RBACPermissions.CommandTicketBugView, true)]
            static bool HandleTicketBugViewCommand(CommandHandler handler, StringArguments args)
            {
                return HandleGetByIdCommand<BugTicket>(handler, args);
            }
        }

        [CommandGroup("complaint")]
        class TicketComplaintCommands
        {
            [Command("assign", RBACPermissions.CommandTicketComplaintAssign, true)]
            static bool HandleTicketComplaintAssignCommand(CommandHandler handler, StringArguments args)
            {
                return HandleTicketAssignToCommand<ComplaintTicket>(handler, args);
            }

            [Command("close", RBACPermissions.CommandTicketComplaintClose, true)]
            static bool HandleTicketComplaintCloseCommand(CommandHandler handler, StringArguments args)
            {
                return HandleCloseByIdCommand<ComplaintTicket>(handler, args);
            }

            [Command("closedlist", RBACPermissions.CommandTicketComplaintClosedlist, true)]
            static bool HandleTicketComplaintClosedListCommand(CommandHandler handler, StringArguments args)
            {
                return HandleClosedListCommand<ComplaintTicket>(handler, args);
            }

            [Command("comment", RBACPermissions.CommandTicketComplaintComment, true)]
            static bool HandleTicketComplaintCommentCommand(CommandHandler handler, StringArguments args)
            {
                return HandleCommentCommand<ComplaintTicket>(handler, args);
            }

            [Command("delete", RBACPermissions.CommandTicketComplaintDelete, true)]
            static bool HandleTicketComplaintDeleteCommand(CommandHandler handler, StringArguments args)
            {
                return HandleDeleteByIdCommand<ComplaintTicket>(handler, args);
            }

            [Command("list", RBACPermissions.CommandTicketComplaintList, true)]
            static bool HandleTicketComplaintListCommand(CommandHandler handler, StringArguments args)
            {
                return HandleListCommand<ComplaintTicket>(handler, args);
            }

            [Command("unassign", RBACPermissions.CommandTicketComplaintUnassign, true)]
            static bool HandleTicketComplaintUnAssignCommand(CommandHandler handler, StringArguments args)
            {
                return HandleUnAssignCommand<ComplaintTicket>(handler, args);
            }

            [Command("view", RBACPermissions.CommandTicketComplaintView, true)]
            static bool HandleTicketComplaintViewCommand(CommandHandler handler, StringArguments args)
            {
                return HandleGetByIdCommand<ComplaintTicket>(handler, args);
            }
        }

        [CommandGroup("suggestion")]
        class TicketSuggestionCommands
        {
            [Command("assign", RBACPermissions.CommandTicketSuggestionAssign, true)]
            static bool HandleTicketSuggestionAssignCommand(CommandHandler handler, StringArguments args)
            {
                return HandleTicketAssignToCommand<SuggestionTicket>(handler, args);
            }

            [Command("close", RBACPermissions.CommandTicketSuggestionClose, true)]
            static bool HandleTicketSuggestionCloseCommand(CommandHandler handler, StringArguments args)
            {
                return HandleCloseByIdCommand<SuggestionTicket>(handler, args);
            }

            [Command("closedlist", RBACPermissions.CommandTicketSuggestionClosedlist, true)]
            static bool HandleTicketSuggestionClosedListCommand(CommandHandler handler, StringArguments args)
            {
                return HandleClosedListCommand<SuggestionTicket>(handler, args);
            }

            [Command("comment", RBACPermissions.CommandTicketSuggestionComment, true)]
            static bool HandleTicketSuggestionCommentCommand(CommandHandler handler, StringArguments args)
            {
                return HandleCommentCommand<SuggestionTicket>(handler, args);
            }

            [Command("delete", RBACPermissions.CommandTicketSuggestionDelete, true)]
            static bool HandleTicketSuggestionDeleteCommand(CommandHandler handler, StringArguments args)
            {
                return HandleDeleteByIdCommand<SuggestionTicket>(handler, args);
            }

            [Command("list", RBACPermissions.CommandTicketSuggestionList, true)]
            static bool HandleTicketSuggestionListCommand(CommandHandler handler, StringArguments args)
            {
                return HandleListCommand<SuggestionTicket>(handler, args);
            }

            [Command("unassign", RBACPermissions.CommandTicketSuggestionUnassign, true)]
            static bool HandleTicketSuggestionUnAssignCommand(CommandHandler handler, StringArguments args)
            {
                return HandleUnAssignCommand<SuggestionTicket>(handler, args);
            }

            [Command("view", RBACPermissions.CommandTicketSuggestionView, true)]
            static bool HandleTicketSuggestionViewCommand(CommandHandler handler, StringArguments args)
            {
                return HandleGetByIdCommand<SuggestionTicket>(handler, args);
            }
        }

        [CommandGroup("reset")]
        class TicketResetCommands
        {
            [Command("all", RBACPermissions.CommandTicketResetAll, true)]
            static bool HandleTicketResetAllCommand(CommandHandler handler, StringArguments args)
            {
                if (Global.SupportMgr.GetOpenTicketCount<BugTicket>() != 0 || Global.SupportMgr.GetOpenTicketCount<ComplaintTicket>() != 0 || Global.SupportMgr.GetOpenTicketCount<SuggestionTicket>() != 0)
                {
                    handler.SendSysMessage(CypherStrings.CommandTicketpending);
                    return true;
                }
                else
                {
                    Global.SupportMgr.ResetTickets<BugTicket>();
                    Global.SupportMgr.ResetTickets<ComplaintTicket>();
                    Global.SupportMgr.ResetTickets<SuggestionTicket>();
                    handler.SendSysMessage(CypherStrings.CommandTicketreset);
                }
                return true;
            }

            [Command("bug", RBACPermissions.CommandTicketResetBug, true)]
            static bool HandleTicketResetBugCommand(CommandHandler handler, StringArguments args)
            {
                return HandleResetCommand<BugTicket>(handler, args);
            }

            [Command("complaint", RBACPermissions.CommandTicketResetComplaint, true)]
            static bool HandleTicketResetComplaintCommand(CommandHandler handler, StringArguments args)
            {
                return HandleResetCommand<ComplaintTicket>(handler, args);
            }

            [Command("suggestion", RBACPermissions.CommandTicketResetSuggestion, true)]
            static bool HandleTicketResetSuggestionCommand(CommandHandler handler, StringArguments args)
            {
                return HandleResetCommand<SuggestionTicket>(handler, args);
            }
        }

        static bool HandleTicketAssignToCommand<T>(CommandHandler handler, StringArguments args) where T : Ticket
        {
            if (args.Empty())
                return false;

            uint ticketId = args.NextUInt32();

            string target = args.NextString();
            if (string.IsNullOrEmpty(target))
                return false;

            if (!ObjectManager.NormalizePlayerName(ref target))
                return false;

            T ticket = Global.SupportMgr.GetTicket<T>(ticketId);
            if (ticket == null || ticket.IsClosed())
            {
                handler.SendSysMessage(CypherStrings.CommandTicketnotexist);
                return true;
            }

            ObjectGuid targetGuid = Global.CharacterCacheStorage.GetCharacterGuidByName(target);
            uint accountId = Global.CharacterCacheStorage.GetCharacterAccountIdByGuid(targetGuid);
            // Target must exist and have administrative rights
            if (!Global.AccountMgr.HasPermission(accountId, RBACPermissions.CommandsBeAssignedTicket, Global.WorldMgr.GetRealm().Id.Index))
            {
                handler.SendSysMessage(CypherStrings.CommandTicketassignerrorA);
                return true;
            }

            // If already assigned, leave
            if (ticket.IsAssignedTo(targetGuid))
            {
                handler.SendSysMessage(CypherStrings.CommandTicketassignerrorB, ticket.GetId());
                return true;
            }

            // If assigned to different player other than current, leave
            //! Console can override though
            Player player = handler.GetSession() != null ? handler.GetSession().GetPlayer() : null;
            if (player && ticket.IsAssignedNotTo(player.GetGUID()))
            {
                handler.SendSysMessage(CypherStrings.CommandTicketalreadyassigned, ticket.GetId());
                return true;
            }

            // Assign ticket
            ticket.SetAssignedTo(targetGuid, Global.AccountMgr.IsAdminAccount(Global.AccountMgr.GetSecurity(accountId, (int)Global.WorldMgr.GetRealm().Id.Index)));
            ticket.SaveToDB();

            string msg = ticket.FormatViewMessageString(handler, null, target, null, null);
            handler.SendGlobalGMSysMessage(msg);
            return true;
        }

        static bool HandleCloseByIdCommand<T>(CommandHandler handler, StringArguments args) where T : Ticket
        {
            if (args.Empty())
                return false;

            uint ticketId = args.NextUInt32();
            T ticket = Global.SupportMgr.GetTicket<T>(ticketId);
            if (ticket == null || ticket.IsClosed())
            {
                handler.SendSysMessage(CypherStrings.CommandTicketnotexist);
                return true;
            }

            // Ticket should be assigned to the player who tries to close it.
            // Console can override though
            Player player = handler.GetSession() != null ? handler.GetSession().GetPlayer() : null;
            if (player && ticket.IsAssignedNotTo(player.GetGUID()))
            {
                handler.SendSysMessage(CypherStrings.CommandTicketcannotclose, ticket.GetId());
                return true;
            }

            ObjectGuid closedByGuid = ObjectGuid.Empty;
            if (player)
                closedByGuid = player.GetGUID();
            else
                closedByGuid.SetRawValue(0, ulong.MaxValue);

            Global.SupportMgr.CloseTicket<T>(ticket.GetId(), closedByGuid);

            string msg = ticket.FormatViewMessageString(handler, player ? player.GetName() : "Console", null, null, null);
            handler.SendGlobalGMSysMessage(msg);

            return true;
        }

        static bool HandleClosedListCommand<T>(CommandHandler handler, StringArguments args) where T : Ticket
        {
            Global.SupportMgr.ShowClosedList<T>(handler);
            return true;
        }

        static bool HandleCommentCommand<T>(CommandHandler handler, StringArguments args) where T : Ticket
        {
            if (args.Empty())
                return false;

            uint ticketId = args.NextUInt32();

            string comment = args.NextString("\n");
            if (string.IsNullOrEmpty(comment))
                return false;

            T ticket = Global.SupportMgr.GetTicket<T>(ticketId);
            if (ticket == null || ticket.IsClosed())
            {
                handler.SendSysMessage(CypherStrings.CommandTicketnotexist);
                return true;
            }

            // Cannot comment ticket assigned to someone else
            //! Console excluded
            Player player = handler.GetSession() != null ? handler.GetSession().GetPlayer() : null;
            if (player && ticket.IsAssignedNotTo(player.GetGUID()))
            {
                handler.SendSysMessage(CypherStrings.CommandTicketalreadyassigned, ticket.GetId());
                return true;
            }

            ticket.SetComment(comment);
            ticket.SaveToDB();
            Global.SupportMgr.UpdateLastChange();

            string msg = ticket.FormatViewMessageString(handler, null, ticket.GetAssignedToName(), null, null);
            msg += string.Format(handler.GetCypherString(CypherStrings.CommandTicketlistaddcomment), player ? player.GetName() : "Console", comment);
            handler.SendGlobalGMSysMessage(msg);

            return true;
        }

        static bool HandleDeleteByIdCommand<T>(CommandHandler handler, StringArguments args) where T : Ticket
        {
            if (args.Empty())
                return false;

            uint ticketId = args.NextUInt32();
            T ticket = Global.SupportMgr.GetTicket<T>(ticketId);
            if (ticket == null)
            {
                handler.SendSysMessage(CypherStrings.CommandTicketnotexist);
                return true;
            }

            if (!ticket.IsClosed())
            {
                handler.SendSysMessage(CypherStrings.CommandTicketclosefirst);
                return true;
            }

            string msg = ticket.FormatViewMessageString(handler, null, null, null, handler.GetSession() != null ? handler.GetSession().GetPlayer().GetName() : "Console");
            handler.SendGlobalGMSysMessage(msg);

            Global.SupportMgr.RemoveTicket<T>(ticket.GetId());

            return true;
        }

        static bool HandleListCommand<T>(CommandHandler handler, StringArguments args) where T : Ticket
        {
            Global.SupportMgr.ShowList<T>(handler);
            return true;
        }

        static bool HandleResetCommand<T>(CommandHandler handler, StringArguments args) where T : Ticket
        {
            if (Global.SupportMgr.GetOpenTicketCount<T>() != 0)
            {
                handler.SendSysMessage(CypherStrings.CommandTicketpending);
                return true;
            }
            else
            {
                Global.SupportMgr.ResetTickets<T>();
                handler.SendSysMessage(CypherStrings.CommandTicketreset);
            }

            return true;
        }

        static bool HandleUnAssignCommand<T>(CommandHandler handler, StringArguments args) where T : Ticket
        {
            if (args.Empty())
                return false;

            uint ticketId = args.NextUInt32();
            T ticket = Global.SupportMgr.GetTicket<T>(ticketId);
            if (ticket == null || ticket.IsClosed())
            {
                handler.SendSysMessage(CypherStrings.CommandTicketnotexist);
                return true;
            }
            // Ticket must be assigned
            if (!ticket.IsAssigned())
            {
                handler.SendSysMessage(CypherStrings.CommandTicketnotassigned, ticket.GetId());
                return true;
            }

            // Get security level of player, whom this ticket is assigned to
            AccountTypes security;
            Player assignedPlayer = ticket.GetAssignedPlayer();
            if (assignedPlayer && assignedPlayer.IsInWorld)
                security = assignedPlayer.GetSession().GetSecurity();
            else
            {
                ObjectGuid guid = ticket.GetAssignedToGUID();
                uint accountId = Global.CharacterCacheStorage.GetCharacterAccountIdByGuid(guid);
                security = Global.AccountMgr.GetSecurity(accountId, (int)Global.WorldMgr.GetRealm().Id.Index);
            }

            // Check security
            //! If no m_session present it means we're issuing this command from the console
            AccountTypes mySecurity = handler.GetSession() != null ? handler.GetSession().GetSecurity() : AccountTypes.Console;
            if (security > mySecurity)
            {
                handler.SendSysMessage(CypherStrings.CommandTicketunassignsecurity);
                return true;
            }

            string assignedTo = ticket.GetAssignedToName(); // copy assignedto name because we need it after the ticket has been unnassigned

            ticket.SetUnassigned();
            ticket.SaveToDB();
            string msg = ticket.FormatViewMessageString(handler, null, assignedTo, handler.GetSession() != null ? handler.GetSession().GetPlayer().GetName() : "Console", null);
            handler.SendGlobalGMSysMessage(msg);

            return true;
        }

        static bool HandleGetByIdCommand<T>(CommandHandler handler, StringArguments args) where T : Ticket
        {
            if (args.Empty())
                return false;

            uint ticketId = args.NextUInt32();
            T ticket = Global.SupportMgr.GetTicket<T>(ticketId);
            if (ticket == null || ticket.IsClosed())
            {
                handler.SendSysMessage(CypherStrings.CommandTicketnotexist);
                return true;
            }

            handler.SendSysMessage(ticket.FormatViewMessageString(handler, true));
            return true;
        }
    }
}
