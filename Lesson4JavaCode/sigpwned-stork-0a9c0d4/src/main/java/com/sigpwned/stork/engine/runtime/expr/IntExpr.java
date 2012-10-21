package com.sigpwned.stork.engine.runtime.expr;

import com.sigpwned.stork.engine.runtime.Expr;
import com.sigpwned.stork.engine.runtime.Scope;

public class IntExpr extends Expr {
	private long value;
	
	public IntExpr(long value) {
		this.value = value;
	}
	
	public long getValue() {
		return value;
	}

	public Object eval(Scope scope) {
		return Long.valueOf(getValue());
	}
}
