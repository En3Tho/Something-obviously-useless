module TGOrganizer.TelegramApi.ActivePatterns

open Telegram.Bot.Types
open Telegram.Bot.Types.Enums

type BotToken = string

module Update =
    let inline (|Unknown|_|) (update: Update) =
        match update.Type with
        | UpdateType.Unknown -> Some()
        | _ -> None

    let inline (|Message|_|) (update: Update) =
        match update.Type with
        | UpdateType.Message -> Some update.Message
        | _ -> None

    let inline (|InlineQuery|_|) (update: Update) =
        match update.Type with
        | UpdateType.InlineQuery -> Some update.InlineQuery
        | _ -> None

    let inline (|ChosenInlineResult|_|) (update: Update) =
        match update.Type with
        | UpdateType.ChosenInlineResult -> Some update.ChosenInlineResult
        | _ -> None

    let inline (|CallbackQuery|_|) (update: Update) =
        match update.Type with
        | UpdateType.CallbackQuery -> Some update.CallbackQuery
        | _ -> None

    let inline (|EditedMessage|_|) (update: Update) =
        match update.Type with
        | UpdateType.EditedMessage -> Some update.EditedMessage
        | _ -> None


    let inline (|ChannelPost|_|) (update: Update) =
        match update.Type with
        | UpdateType.ChannelPost -> Some update.ChannelPost
        | _ -> None

    let inline (|EditedChannelPost|_|) (update: Update) =
        match update.Type with
        | UpdateType.EditedChannelPost -> Some update.EditedChannelPost
        | _ -> None

    let inline (|ShippingQuery|_|) (update: Update) =
        match update.Type with
        | UpdateType.ShippingQuery -> Some update.ShippingQuery
        | _ -> None

    let inline (|PreCheckoutQuery|_|) (update: Update) =
        match update.Type with
        | UpdateType.PreCheckoutQuery -> Some update.PreCheckoutQuery
        | _ -> None

    let inline (|Poll|_|) (update: Update) =
        match update.Type with
        | UpdateType.Poll -> Some update.Poll
        | _ -> None


    let inline (|PollAnswer|_|) (update: Update) =
        match update.Type with
        | UpdateType.PollAnswer -> Some update.PollAnswer
        | _ -> None

    let inline (|MyChatMember|_|) (update: Update) =
        match update.Type with
        | UpdateType.MyChatMember -> Some update.MyChatMember
        | _ -> None

    let inline (|ChatMember|_|) (update: Update) =
        match update.Type with
        | UpdateType.ChatMember -> Some update.ChatMember
        | _ -> None

module Message =

    let inline (|Text|_|) (message: Message) =
        match message.Type with
        | MessageType.Text -> Some message.Text
        | _ -> None

    let inline (|Caption|_|) (message: Message) =
        message.Caption |> Option.ofObj

    let inline (|Photo|_|) (message: Message) =
        match message.Type with
        | MessageType.Photo -> Some message.Photo
        | _ -> None

    let inline (|Audio|_|) (message: Message) =
        match message.Type with
        | MessageType.Audio -> Some message.Audio
        | _ -> None

    let inline (|Video|_|) (message: Message) =
        match message.Type with
        | MessageType.Video -> Some message.Video
        | _ -> None

    let inline (|Voice|_|) (message: Message) =
        match message.Type with
        | MessageType.Voice -> Some message.Voice
        | _ -> None

    let inline (|Document|_|) (message: Message) =
        match message.Type with
        | MessageType.Document -> Some message.Document
        | _ -> None

    let inline (|Sticker|_|) (message: Message) =
        match message.Type with
        | MessageType.Sticker -> Some message.Sticker
        | _ -> None

    let inline (|Location|_|) (message: Message) =
        match message.Type with
        | MessageType.Location -> Some message.Location
        | _ -> None

    let inline (|Contact|_|) (message: Message) =
        match message.Type with
        | MessageType.Contact -> Some message.Contact
        | _ -> None

    let inline (|Venue|_|) (message: Message) =
        match message.Type with
        | MessageType.Venue -> Some message.Venue
        | _ -> None

    let inline (|Game|_|) (message: Message) =
        match message.Type with
        | MessageType.Game -> Some message.Game
        | _ -> None

    let inline (|VideoNote|_|) (message: Message) =
        match message.Type with
        | MessageType.VideoNote -> Some message.VideoNote
        | _ -> None

    let inline (|Invoice|_|) (message: Message) =
        match message.Type with
        | MessageType.Invoice -> Some message.Invoice
        | _ -> None

    let inline (|SuccessfulPayment|_|) (message: Message) =
        match message.Type with
        | MessageType.SuccessfulPayment -> Some message.SuccessfulPayment
        | _ -> None

    let inline (|WebsiteConnected|_|) (message: Message) =
        match message.Type with
        | MessageType.WebsiteConnected -> Some message.ConnectedWebsite
        | _ -> None

    let inline (|ChatMembersAdded|_|) (message: Message) =
        match message.Type with
        | MessageType.ChatMembersAdded -> Some message.NewChatMembers
        | _ -> None

    let inline (|ChatMemberLeft|_|) (message: Message) =
        match message.Type with
        | MessageType.ChatMemberLeft -> Some message.LeftChatMember
        | _ -> None

    let inline (|ChatTitleChanged|_|) (message: Message) =
        match message.Type with
        | MessageType.ChatTitleChanged -> Some message.NewChatTitle
        | _ -> None

    let inline (|ChatPhotoChanged|_|) (message: Message) =
        match message.Type with
        | MessageType.ChatPhotoChanged -> Some message.NewChatPhoto
        | _ -> None

    let inline (|MessagePinned|_|) (message: Message) =
        match message.Type with
        | MessageType.MessagePinned -> Some message.PinnedMessage
        | _ -> None

    let inline (|ChatPhotoDeleted|_|) (message: Message) =
        match message.Type with
        | MessageType.ChatPhotoDeleted -> Some message.DeleteChatPhoto
        | _ -> None

    let inline (|GroupCreated|_|) (message: Message) =
        match message.Type with
        | MessageType.GroupCreated -> Some message.GroupChatCreated
        | _ -> None

    let inline (|SupergroupCreated|_|) (message: Message) =
        match message.Type with
        | MessageType.SupergroupCreated -> Some message.SupergroupChatCreated
        | _ -> None

    let inline (|ChannelCreated|_|) (message: Message) =
        match message.Type with
        | MessageType.ChannelCreated -> Some message.ChannelChatCreated
        | _ -> None

    let inline (|MigratedToSupergroup|_|) (message: Message) =
        match message.Type with
        | MessageType.MigratedToSupergroup -> Some message.MigrateToChatId
        | _ -> None

    let inline (|MigratedFromGroup|_|) (message: Message) =
        match message.Type with
        | MessageType.MigratedFromGroup -> Some message.MigrateFromChatId
        | _ -> None

    let inline (|Poll|_|) (message: Message) =
        match message.Type with
        | MessageType.Poll -> Some message.Poll
        | _ -> None

    let inline (|Dice|_|) (message: Message) =
        match message.Type with
        | MessageType.Dice -> Some message.Dice
        | _ -> None

    let inline (|MessageAutoDeleteTimerChanged|_|) (message: Message) =
        match message.Type with
        | MessageType.MessageAutoDeleteTimerChanged -> Some message.MessageAutoDeleteTimerChanged
        | _ -> None

    let inline (|ProximityAlertTriggered|_|) (message: Message) =
        match message.Type with
        | MessageType.ProximityAlertTriggered -> Some message.ProximityAlertTriggered
        | _ -> None

    let inline (|VoiceChatScheduled|_|) (message: Message) =
        match message.Type with
        | MessageType.VoiceChatScheduled -> Some message.VoiceChatScheduled
        | _ -> None

    let inline (|VoiceChatStarted|_|) (message: Message) =
        match message.Type with
        | MessageType.VoiceChatStarted -> Some message.VoiceChatStarted
        | _ -> None

    let inline (|VoiceChatEnded|_|) (message: Message) =
        match message.Type with
        | MessageType.VoiceChatEnded -> Some message.VoiceChatEnded
        | _ -> None

    let inline (|VoiceChatParticipantsInvited|_|) (message: Message) =
        match message.Type with
        | MessageType.VoiceChatParticipantsInvited -> Some message.VoiceChatParticipantsInvited
        | _ -> None