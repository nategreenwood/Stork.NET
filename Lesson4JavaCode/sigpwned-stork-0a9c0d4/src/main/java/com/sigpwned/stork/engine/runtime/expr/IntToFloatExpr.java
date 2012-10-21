package com.sigpwned.stork.engine.runtime.expr;

import com.sigpwned.stork.engine.runtime.Expr;
import com.sigpwned.stork.engine.runtime.Scope;

public class IntToFloatExpr extends Expr {
	private Expr inner;
	
	public IntToFloatExpr(Expr inner) {
		this.inner = inner;
	}
	
	public Expr getInner() {
		return inner;
	}
	
	public Object eval(Scope scope) {
		Long value=(Long) getInner().eval(scope);
		return Double.valueOf(value.doubleValue());
	}
}
