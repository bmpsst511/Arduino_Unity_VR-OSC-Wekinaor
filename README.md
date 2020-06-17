---
title: 'GitHub Arduino Sensor OSC Wekinator'
disqus: hackmd
---

## Open Sound Control(OSC) 與 Wekinator 透過慣性感測器之實作
---

[**HACKMD Link**](https://hackmd.io/@J-T-LEE/B1ZfVWSpU)    
[**GITHUB Link**](https://github.com/bmpsst511/Arduino_Unity_VR-OSC-Wekinaor/blob/master/IMU_OSC_Wekinator.cpp) 

---
需要的軟&硬體
---
[**Processing**](https://processing.org/)//
[**Arduino IDE**](https://www.arduino.cc/)//
[**Wekinator**](http://www.wekinator.org/)//
[**Continuously-controlled drum Example**](http://www.wekinator.org/examples/)//
[**BNO055**](https://learn.adafruit.com/adafruit-bno055-absolute-orientation-sensor)//
[**Wemos D1 mini**](https://opencircuit.shop/Product/WeMos-D1-mini-V3.1-Wifi-Module)

---
介紹
---

### Open Sound Control(OSC)
OSC原來是在 UC Berkeley Center for New Music and Audio Technology (CNMAT) 的一個研究計畫。CNMAT 是 UC Berkeley的一個跨學科的研究中心。它以充滿活動的教育，效率，研究計畫而聞名，其專注於音樂與技術創新互動。

用於電腦，聲音合成器和其他多媒體設備之間溝通的架構，該架構針對現代網路技術進行了優化。將現代網路技術的優勢帶到電子數位樂器世界中，OSC的優勢包括相互操作性，準確性，靈活性以及增強的組織和檔案編制能力。總得來說這個簡單而強大的協議提供了**實時控制聲音**和其他媒體處理所需的一切，同時又保持了**靈活性**和**易於實踐性**。

特色:
1. 開放式，動態，URL樣式的符號命名方案
2. 符號和高分辨率數值參數數據
3. 模式匹配語言可指定單個郵件的多個收件人
4. 高分辨率時間標籤
5. 封包與檔案之間，其效果同時發生
6. 查詢系統可動態查找OSC服務器的功能並獲取檔案

OSC已經有數十種作品，包括即時聲音和媒體處理環境，Web互動工具，軟體合成器，多種程式語言以及用於感測器測量的硬體設備。 OSC已在包括基於電腦的音樂表達的新界面，廣域和區域網聯網的分佈式音樂系統，進程間通訊甚至單個應用程序內的領域中得到廣泛使用。

### Wekinator
Wekinator是免費的開源軟體，最初由Rebecca Fiebrink於2009年開發。任何人可以透過Wekinator使用機器學習來構建新的樂器，手勢遊戲控制器，電腦視覺或聽力系統等實作。
Wekinator允許用戶通過演示人類行為和電腦互動來構建新的互動式系統，而無需編寫程式。

---
實作
---

本篇教學文章主要在於帶領大家實作入門Wekinator跟OSC如何整合應用

首先打開先前已經下載好的Continuously-controlled drum Example，在setup()裡會看到設定好的Port，12000與6448。

![](https://i.imgur.com/L2znbyQ.png)

接著打開Wekinator會看到預先設定好的6448與12000，這時要修改的是outputs，由於鼓的音源輸出檔為三個因此將outputs數量改為3。

![](https://i.imgur.com/rv3Hlbp.png)

按下Next後，就會進入到Wekinator的控制介面，在OSC In 與 OSC out 為黃燈的狀態代表目前還沒收到與輸出資料

![](https://i.imgur.com/7W0mFfL.png)

這時候可以在Processing裡執行鼓的範例並按下Wek介面裡randomize的按鈕，鼓的範例介面就會隨機發出音樂，如果沒有成功，再回去檢查Processing裡的範例程式Port的設定是否與Wekinator的設定一致。

![](https://i.imgur.com/hqtxOYk.png)

到這裡基本上可以確認現在擁有音樂輸出的功能了，接下來我們要給定輸入的資料，這裡以慣性感測器為例，而關於慣性感測器BNO055的教學可以參考我以前的教學內容找到詳情
請見:[**實作九軸慣性感測器於Unity內即時無線傳輸控制方塊**](https://github.com/bmpsst511/Arduino_Wireless_Sensors/tree/master/IMU%20BNO055)

至於與OSC與Wekinator的程式在以下的連結
請下載我GITHUB裡寫好的[**慣性感測器資料Push給OSC**](https://github.com/bmpsst511/Arduino_Unity_VR-OSC-Wekinaor/blob/master/IMU_OSC_Wekinator.cpp)

在程式裡面我修改了慣性感測器給Wekinator的outPort為6448，是原始Wekinator預設的。而localPort更改為6969，目的是為了不跟Processing與Wekinator的12000Port衝突。

![](https://i.imgur.com/XXYN7pS.png)

當程式燒入Wemos D1 mini後與Wekinator相連，當看到OSC In亮綠燈，並確認收到感測器傳來的數值。

![](https://i.imgur.com/KjONx61.png)

![](https://i.imgur.com/BsyMEfy.png)

---
實現
---
![](https://j.gifs.com/XLGj0V.gif)








###### tags: `GITHUB`
