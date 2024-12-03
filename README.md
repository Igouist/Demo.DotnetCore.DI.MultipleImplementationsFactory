## Demo.DotnetCore.DI.MultipleImplementationsFactory
展示 DI 註冊同個 Interface 的實作，並且製作一個根據傳入值字串取得不同實作的工廠

- IFruit: 目標 Interface & 相關實作（Apple, Orange, Banana）
- IFruitFactory: 示範用 Factory, 注入 IEnumerable<IFruit> 並用 FirstOrDefault 取得指定實作
- Startup: 在 ConfigureServices 註冊 IFruit 及 IFruitFactory 的實作
- DemoController: 呼叫 IFruitFactory, 測試用
