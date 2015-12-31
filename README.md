# lndapi
C# wrapper for the Luna Node Dynamic API

Luna Node provides high performance cloud servers in Toronto, Montreal, and Roubaix (France).<br />
See https://dynamic.lunanode.com/info.php?r=2427 for more info (aff. link)

Their service includes an API that can be used to automate parts of the control panel, which is pretty easy to use, but lndapi makes it even easier!

<strong>This is still in the early stages of development, so only a small subset of the API has been implemented so far. The rest is in the works...</strong>

# Supported Actions

<strong>vm</strong>: start, stop, reboot, info, delete, reimage, resize, rescue, vnc, snapshot, list<br />
<strong>image</strong>: list, delete, details, replicate, retrieve<br />

# Unsupported Actions (for now)

<strong>vm</strong>: diskswap, floatingip-add, floatingip-delete, create<br />
<strong>image</strong>: fetch<br />
