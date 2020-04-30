ScriptableAction 的作用是使用 ScriptableObject 来存储方法（代码）
便于不同类调用同一代码逻辑，类似与传统的静态工具类

两种普遍用法：

1.调用者引用 ScriptableAction 资源并执行 Invoke 方法

2.结合 GameEvent 使用，通过 GameEventListener 的 UnityEvent 绑定 ScriptableAction 来执行 Invoke 方法