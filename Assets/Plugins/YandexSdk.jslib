mergeInto(LibraryManager.library, 
{
	SaveExtern: function(data)
	{
		var save = JSON.parse(UTF8ToString(data));
		player.setData(save);
	},
	
	LoadExtern: function()
	{
		player.getData().then(_date =>
		{
			const myJSON = JSON.stringify(_date);
			myGame.SendMessage('DataHolder', 'SetData', myJSON);
		})
	},
	
	RewardShowAdsExtern: function()
	{
		ysdk.adv.showRewardedVideo(
		{
			callbacks: 
			{
				onOpen: () => {
				  console.log('Video ad open.');
				},
				onRewarded: () => {
				  myGame.SendMessage('YandexSdk', 'Reward');
				},
				onClose: () => {
					myGame.SendMessage('YandexSdk', 'CompliteAds');
				}, 
				onError: (e) => {
					myGame.SendMessage('YandexSdk', 'CompliteAds');
				}
			}
		})
	},
	
	ShowBannerAdsExtern: function()
	{
		ysdk.adv.showFullscreenAdv(
		{
			callbacks: {
				onClose: function(wasShown) {
					myGame.SendMessage('YandexSdk', 'CompliteAds');
				},
				onError: function(error) {
					myGame.SendMessage('YandexSdk', 'CompliteAds');
				}
			}
		})
	},
});