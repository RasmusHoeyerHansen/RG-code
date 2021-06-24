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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IRGCodeListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.1")]
[System.Diagnostics.DebuggerNonUserCode]
[System.CLSCompliant(false)]
public partial class RGCodeBaseListener : IRGCodeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProgram([NotNull] RGCodeParser.ProgramContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProgram([NotNull] RGCodeParser.ProgramContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatement([NotNull] RGCodeParser.StatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatement([NotNull] RGCodeParser.StatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.vardec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVardec([NotNull] RGCodeParser.VardecContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.vardec"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVardec([NotNull] RGCodeParser.VardecContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignment([NotNull] RGCodeParser.AssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignment([NotNull] RGCodeParser.AssignmentContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpr([NotNull] RGCodeParser.ExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpr([NotNull] RGCodeParser.ExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>plusminus</c>
	/// labeled alternative in <see cref="RGCodeParser.math"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPlusminus([NotNull] RGCodeParser.PlusminusContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>plusminus</c>
	/// labeled alternative in <see cref="RGCodeParser.math"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPlusminus([NotNull] RGCodeParser.PlusminusContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>singleTerm</c>
	/// labeled alternative in <see cref="RGCodeParser.math"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSingleTerm([NotNull] RGCodeParser.SingleTermContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>singleTerm</c>
	/// labeled alternative in <see cref="RGCodeParser.math"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSingleTerm([NotNull] RGCodeParser.SingleTermContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>multiplication</c>
	/// labeled alternative in <see cref="RGCodeParser.term"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultiplication([NotNull] RGCodeParser.MultiplicationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>multiplication</c>
	/// labeled alternative in <see cref="RGCodeParser.term"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultiplication([NotNull] RGCodeParser.MultiplicationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>singleFactor</c>
	/// labeled alternative in <see cref="RGCodeParser.term"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSingleFactor([NotNull] RGCodeParser.SingleFactorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>singleFactor</c>
	/// labeled alternative in <see cref="RGCodeParser.term"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSingleFactor([NotNull] RGCodeParser.SingleFactorContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>power</c>
	/// labeled alternative in <see cref="RGCodeParser.factor"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPower([NotNull] RGCodeParser.PowerContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>power</c>
	/// labeled alternative in <see cref="RGCodeParser.factor"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPower([NotNull] RGCodeParser.PowerContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>singeAtom</c>
	/// labeled alternative in <see cref="RGCodeParser.factor"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSingeAtom([NotNull] RGCodeParser.SingeAtomContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>singeAtom</c>
	/// labeled alternative in <see cref="RGCodeParser.factor"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSingeAtom([NotNull] RGCodeParser.SingeAtomContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>parentheseis</c>
	/// labeled alternative in <see cref="RGCodeParser.factor"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParentheseis([NotNull] RGCodeParser.ParentheseisContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>parentheseis</c>
	/// labeled alternative in <see cref="RGCodeParser.factor"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParentheseis([NotNull] RGCodeParser.ParentheseisContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>value</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterValue([NotNull] RGCodeParser.ValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>value</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitValue([NotNull] RGCodeParser.ValueContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>idMath</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIdMath([NotNull] RGCodeParser.IdMathContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>idMath</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIdMath([NotNull] RGCodeParser.IdMathContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>boolExpression</c>
	/// labeled alternative in <see cref="RGCodeParser.bool"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBoolExpression([NotNull] RGCodeParser.BoolExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>boolExpression</c>
	/// labeled alternative in <see cref="RGCodeParser.bool"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBoolExpression([NotNull] RGCodeParser.BoolExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>pointExpression</c>
	/// labeled alternative in <see cref="RGCodeParser.point"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterPointExpression([NotNull] RGCodeParser.PointExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>pointExpression</c>
	/// labeled alternative in <see cref="RGCodeParser.point"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitPointExpression([NotNull] RGCodeParser.PointExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>idPoint</c>
	/// labeled alternative in <see cref="RGCodeParser.point"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIdPoint([NotNull] RGCodeParser.IdPointContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>idPoint</c>
	/// labeled alternative in <see cref="RGCodeParser.point"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIdPoint([NotNull] RGCodeParser.IdPointContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.move"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMove([NotNull] RGCodeParser.MoveContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.move"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMove([NotNull] RGCodeParser.MoveContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>lineCommand</c>
	/// labeled alternative in <see cref="RGCodeParser.line"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLineCommand([NotNull] RGCodeParser.LineCommandContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>lineCommand</c>
	/// labeled alternative in <see cref="RGCodeParser.line"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLineCommand([NotNull] RGCodeParser.LineCommandContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>curveCommand</c>
	/// labeled alternative in <see cref="RGCodeParser.curve"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCurveCommand([NotNull] RGCodeParser.CurveCommandContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>curveCommand</c>
	/// labeled alternative in <see cref="RGCodeParser.curve"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCurveCommand([NotNull] RGCodeParser.CurveCommandContext context) { }
	/// <summary>
	/// Enter a parse tree produced by the <c>to</c>
	/// labeled alternative in <see cref="RGCodeParser.toCommands"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTo([NotNull] RGCodeParser.ToContext context) { }
	/// <summary>
	/// Exit a parse tree produced by the <c>to</c>
	/// labeled alternative in <see cref="RGCodeParser.toCommands"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTo([NotNull] RGCodeParser.ToContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.repeat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRepeat([NotNull] RGCodeParser.RepeatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.repeat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRepeat([NotNull] RGCodeParser.RepeatContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.if"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIf([NotNull] RGCodeParser.IfContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.if"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIf([NotNull] RGCodeParser.IfContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="RGCodeParser.ifElse"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIfElse([NotNull] RGCodeParser.IfElseContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="RGCodeParser.ifElse"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIfElse([NotNull] RGCodeParser.IfElseContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
