# lndapi
C# wrapper for the Luna Node Dynamic API

Luna Node provides high performance cloud servers in Toronto, Montreal, and Roubaix (France).<br />
See https://dynamic.lunanode.com/info.php?r=2427 for more info (aff. link)

Their service includes an API that can be used to automate parts of the control panel, which is pretty easy to use, but lndapi makes it even easier!

<strong>This is still in the early stages of development, so only a small subset of the API has been implemented so far. The rest is in the works...</strong>

# Supported Actions

<strong>vm</strong>: start, stop, reboot, info, delete, reimage, resize, rescue, vnc, snapshot, list<br />
<strong>dns</strong>: list<br />
<strong>image</strong>: list, delete, details, replicate, fetch, retrieve<br />
<strong>volume</strong>: list<br />
virtual <strong>network</strong>: list<br />
<strong>plan</strong>: list<br />
<strong>region</strong>: list<br />
<strong>securitygroup</strong>: list<br />
startup <strong>script</strong>: list<br />
<strong>billing</strong>: credit<br />

# Unsupported Actions (for now)

<strong>vm</strong>: diskswap, floatingip-add, floatingip-delete, create<br />
<strong>dns</strong>: set, zone-list, zone-add, zone-remove, record-list, record-add, record-remove, dyn-list, dyn-add, dyn-update, dyn-remove<br />
<strong>volume</strong>: create, delete, attach, detach, info<br />
<strong>floating</strong> ip: list, add, delete<br />
virtual <strong>network</strong>: create, delete<br />
<strong>lb</strong> (load balancer): list, create, delete, info, member_add, member_remove, associate<br />
server <strong>monitor</strong>: check-list, check-types, check-add, check-remove, contact-list, contact-add, contact-remove, alert-list, alert-add, alert-remove<br />

