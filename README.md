# IsTDMOk

Recently a friend (A) and an interesting problem. A friend (B) of theirs needed to break off contact to preserve their marriage, however they A was concerned about the health of B who has been dealing with some health things and wanted a way to be able to know if they had won or not, while still maintaining a high degree of 

I've a friend who fell off the map a number of years ago and I still worry about them, wondering if they are alive or dead. The not knowing is the worst.

Wanting to help, I wrote up this quick little two headed Azure Function which can provide such a mechanism.

A timer-based function fires off periodically (currently set to monthly) to send a text via Twilio to the target, who is asked to reply with a numeric response.

Another function will receive any reply, determine if it is a numeric response or not. If it is numeric it will relay the message to another number, if not a reply will be made saying it's an invalid response.

So as to show my work, I'm publishing the source code here, however in order to preserve the privacy of all involved, no phone numbers, names, genders or ailments are spelled out in the code. These values are configured manually in the Azure portal.

Final thing: No, TDM is not the initials of anyone involved.
