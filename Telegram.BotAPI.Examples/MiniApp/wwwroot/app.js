(() => {
  "use strict";

  const minimumVersion = "8.0";
  const webApp = window.Telegram?.WebApp;
  const requestButton = document.querySelector("#request-access");
  const supportBadge = document.querySelector("#support-badge");
  const permissionBadge = document.querySelector("#permission-badge");
  const permissionMessage = document.querySelector("#permission-message");
  const eventBadge = document.querySelector("#event-badge");
  const eventMessage = document.querySelector("#event-message");
  const sendTestDataButton = document.querySelector("#send-test-data");

  const setBadge = (element, text, state) => {
    element.textContent = text;
    element.dataset.state = state;
  };

  const setPermissionResult = (granted) => {
    if (granted) {
      setBadge(permissionBadge, "Granted", "success");
      permissionMessage.textContent =
        "Access granted. The Premium emoji-status live test can now target this account.";
      webApp?.HapticFeedback?.notificationOccurred("success");
      return;
    }

    setBadge(permissionBadge, "Not granted", "error");
    permissionMessage.textContent =
      "Telegram did not grant access. You can request it again when ready.";
    webApp?.HapticFeedback?.notificationOccurred("error");
  };

  if (!webApp?.initData) {
    setBadge(supportBadge, "Browser preview", "error");
    permissionMessage.textContent = "Launch this page from the bot's Main App in Telegram.";
    return;
  }

  webApp.ready();
  webApp.expand();
  sendTestDataButton.disabled = false;

  document.querySelector("#platform").textContent = webApp.platform || "Unknown";
  document.querySelector("#version").textContent = webApp.version || "Unknown";
  document.querySelector("#premium").textContent =
    webApp.initDataUnsafe?.user?.is_premium === true ? "Yes" : "Not reported";

  const supported =
    webApp.isVersionAtLeast(minimumVersion) &&
    typeof webApp.requestEmojiStatusAccess === "function";

  if (!supported) {
    setBadge(supportBadge, "Unsupported", "error");
    permissionMessage.textContent =
      `Telegram Bot API ${minimumVersion} or later is required for this request.`;
    return;
  }

  setBadge(supportBadge, "Ready", "success");
  requestButton.disabled = false;

  webApp.onEvent("emojiStatusAccessRequested", (event) => {
    setPermissionResult(event?.status === "allowed");
  });

  requestButton.addEventListener("click", () => {
    setBadge(permissionBadge, "Waiting", "pending");
    permissionMessage.textContent = "Waiting for your response in Telegram.";
    requestButton.disabled = true;

    webApp.requestEmojiStatusAccess((granted) => {
      setPermissionResult(granted);
      requestButton.disabled = false;
    });
  });

  sendTestDataButton.addEventListener("click", () => {
    setBadge(eventBadge, "Sending", "pending");
    eventMessage.textContent = "Sending test data to the bot.";
    webApp.sendData(JSON.stringify({
      kind: "event-harness",
      sentAt: new Date().toISOString(),
      platform: webApp.platform || "unknown"
    }));
  });
})();
