//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/Rasmus/source/repos/RG-code/RG-code\RGCode.g4 by ANTLR 4.9.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="RGCodeParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.1")]
[System.CLSCompliant(false)]
public interface IRGCodeListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] RGCodeParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] RGCodeParser.ProgramContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] RGCodeParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] RGCodeParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.vardec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVardec([NotNull] RGCodeParser.VardecContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.vardec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVardec([NotNull] RGCodeParser.VardecContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] RGCodeParser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] RGCodeParser.AssignmentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr([NotNull] RGCodeParser.ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr([NotNull] RGCodeParser.ExprContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>plusminus</c>
	/// labeled alternative in <see cref="RGCodeParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPlusminus([NotNull] RGCodeParser.PlusminusContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>plusminus</c>
	/// labeled alternative in <see cref="RGCodeParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPlusminus([NotNull] RGCodeParser.PlusminusContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>singleTerm</c>
	/// labeled alternative in <see cref="RGCodeParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSingleTerm([NotNull] RGCodeParser.SingleTermContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>singleTerm</c>
	/// labeled alternative in <see cref="RGCodeParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSingleTerm([NotNull] RGCodeParser.SingleTermContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>multiplication</c>
	/// labeled alternative in <see cref="RGCodeParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultiplication([NotNull] RGCodeParser.MultiplicationContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>multiplication</c>
	/// labeled alternative in <see cref="RGCodeParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultiplication([NotNull] RGCodeParser.MultiplicationContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>singleFactor</c>
	/// labeled alternative in <see cref="RGCodeParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSingleFactor([NotNull] RGCodeParser.SingleFactorContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>singleFactor</c>
	/// labeled alternative in <see cref="RGCodeParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSingleFactor([NotNull] RGCodeParser.SingleFactorContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>power</c>
	/// labeled alternative in <see cref="RGCodeParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPower([NotNull] RGCodeParser.PowerContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>power</c>
	/// labeled alternative in <see cref="RGCodeParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPower([NotNull] RGCodeParser.PowerContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>singeAtom</c>
	/// labeled alternative in <see cref="RGCodeParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSingeAtom([NotNull] RGCodeParser.SingeAtomContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>singeAtom</c>
	/// labeled alternative in <see cref="RGCodeParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSingeAtom([NotNull] RGCodeParser.SingeAtomContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>value</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValue([NotNull] RGCodeParser.ValueContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>value</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValue([NotNull] RGCodeParser.ValueContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>idMath</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdMath([NotNull] RGCodeParser.IdMathContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>idMath</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdMath([NotNull] RGCodeParser.IdMathContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>compund</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompund([NotNull] RGCodeParser.CompundContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>compund</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompund([NotNull] RGCodeParser.CompundContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>boolExpression</c>
	/// labeled alternative in <see cref="RGCodeParser.bool"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoolExpression([NotNull] RGCodeParser.BoolExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>boolExpression</c>
	/// labeled alternative in <see cref="RGCodeParser.bool"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoolExpression([NotNull] RGCodeParser.BoolExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>pointExpression</c>
	/// labeled alternative in <see cref="RGCodeParser.point"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPointExpression([NotNull] RGCodeParser.PointExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>pointExpression</c>
	/// labeled alternative in <see cref="RGCodeParser.point"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPointExpression([NotNull] RGCodeParser.PointExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>idPoint</c>
	/// labeled alternative in <see cref="RGCodeParser.point"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdPoint([NotNull] RGCodeParser.IdPointContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>idPoint</c>
	/// labeled alternative in <see cref="RGCodeParser.point"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdPoint([NotNull] RGCodeParser.IdPointContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.move"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMove([NotNull] RGCodeParser.MoveContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.move"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMove([NotNull] RGCodeParser.MoveContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>lineCommand</c>
	/// labeled alternative in <see cref="RGCodeParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLineCommand([NotNull] RGCodeParser.LineCommandContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>lineCommand</c>
	/// labeled alternative in <see cref="RGCodeParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLineCommand([NotNull] RGCodeParser.LineCommandContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>curveCommand</c>
	/// labeled alternative in <see cref="RGCodeParser.curve"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCurveCommand([NotNull] RGCodeParser.CurveCommandContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>curveCommand</c>
	/// labeled alternative in <see cref="RGCodeParser.curve"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCurveCommand([NotNull] RGCodeParser.CurveCommandContext context);
	/// <summary>
	/// Enter a parse tree produced by the <c>to</c>
	/// labeled alternative in <see cref="RGCodeParser.toCommands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTo([NotNull] RGCodeParser.ToContext context);
	/// <summary>
	/// Exit a parse tree produced by the <c>to</c>
	/// labeled alternative in <see cref="RGCodeParser.toCommands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTo([NotNull] RGCodeParser.ToContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.repeat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRepeat([NotNull] RGCodeParser.RepeatContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.repeat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRepeat([NotNull] RGCodeParser.RepeatContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.if"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIf([NotNull] RGCodeParser.IfContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.if"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIf([NotNull] RGCodeParser.IfContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.ifElse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfElse([NotNull] RGCodeParser.IfElseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.ifElse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfElse([NotNull] RGCodeParser.IfElseContext context);
}
