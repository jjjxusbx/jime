;; rules/xss_rule.wat
(module
  (memory (export "memory") 1)
  (func $alloc (export "alloc") (param i32) (result i32)
    ;; 简化内存分配（实际需实现内存管理）
    i32.const 0
  )
  (func (export "validate") (param i32) (result i32)
    (local $input i32)
    (local.set $input (i32.load (local.get 0)))

    ;; 检测XSS特征
    (if (call $contains (local.get $input) (i32.const 60) (i32.const 47)) ;; 检测 </
      (then (return (i32.const 1)))
    (i32.const 0)
  )

  (func $contains (param $ptr i32) (param $char1 i32) (param $char2 i32) (result i32)
    ;; 内存扫描逻辑（简化版）
    (i32.and
      (i32.eq (i32.load8_u (local.get $ptr)) (local.get $char1))
      (i32.eq (i32.load8_u (i32.add (local.get $ptr) (i32.const 1))) (local.get $char2)))
  )
)