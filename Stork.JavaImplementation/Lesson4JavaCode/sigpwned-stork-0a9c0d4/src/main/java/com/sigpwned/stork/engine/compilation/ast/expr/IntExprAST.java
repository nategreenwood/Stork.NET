package com.sigpwned.stork.engine.compilation.ast.expr;

import com.sigpwned.stork.engine.compilation.Translator;
import com.sigpwned.stork.engine.compilation.Type;
import com.sigpwned.stork.engine.compilation.ast.ExprAST;
import com.sigpwned.stork.engine.runtime.Expr;

public class IntExprAST extends ExprAST {
	private long value;
	
	public IntExprAST(long value) {
		this.value = value;
	}

	public long getValue() {
		return value;
	}

	public Expr translate(Translator translator) {
		return translator.translate(this);
	}

	public Expr assign(Translator translate, ExprAST value) {
		return translate.assign(this, value);
	}
	
	public Type typeOf(Translator translate) {
		return translate.typeOf(this);
	}
}
