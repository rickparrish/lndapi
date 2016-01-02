# lndapi
C# wrapper for the Luna Node Dynamic API

Luna Node provides high performance cloud servers in Toronto, Montreal, and Roubaix (France).<br />
See https://dynamic.lunanode.com/info.php?r=2427 for more info (aff. link)

Their service includes an API that can be used to automate parts of the control panel, which is pretty easy to use, but lndapi makes it even easier!

For a real-world example of its usage, check out <a href="https://github.com/rickparrish/lndbackup">lndbackup</a>

<strong>This is still in the early stages of development, so while I've tested every method as I've added them, there could still be bugs and edge cases to work out.</strong>

# Supported Actions

<strong>vm</strong>: start, stop, reboot, info, delete, reimage, resize, rescue, vnc, create, snapshot, list<br />
<strong>dns</strong>: list<br />
<strong>image</strong>: list, delete, details, replicate, fetch, retrieve<br />
<strong>volume</strong>: list, delete<br />
<strong>floating</strong> ip: list<br />
virtual <strong>network</strong>: list, delete<br />
<strong>lb</strong> (load balancer): list, delete<br />
<strong>plan</strong>: list<br />
<strong>region</strong>: list<br />
<strong>securitygroup</strong>: list<br />
startup <strong>script</strong>: list<br />
<strong>billing</strong>: credit<br />

# Unsupported Actions (for now)

<strong>vm</strong>: diskswap, floatingip-add, floatingip-delete<br />
<strong>dns</strong>: set, zone-list, zone-add, zone-remove, record-list, record-add, record-remove, dyn-list, dyn-add, dyn-update, dyn-remove<br />
<strong>volume</strong>: create, attach, detach, info<br />
<strong>floating</strong> ip: add, delete<br />
virtual <strong>network</strong>: create<br />
<strong>lb</strong> (load balancer): create, info, member_add, member_remove, associate<br />
server <strong>monitor</strong>: check-list, check-types, check-add, check-remove, contact-list, contact-add, contact-remove, alert-list, alert-add, alert-remove<br />

