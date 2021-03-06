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
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="RGCodeParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.1")]
[System.CLSCompliant(false)]
public interface IRGCodeVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="RGCodeParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] RGCodeParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RGCodeParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] RGCodeParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RGCodeParser.vardec"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVardec([NotNull] RGCodeParser.VardecContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RGCodeParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] RGCodeParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RGCodeParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] RGCodeParser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>plusminus</c>
	/// labeled alternative in <see cref="RGCodeParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPlusminus([NotNull] RGCodeParser.PlusminusContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>singleTerm</c>
	/// labeled alternative in <see cref="RGCodeParser.math"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSingleTerm([NotNull] RGCodeParser.SingleTermContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>multiplication</c>
	/// labeled alternative in <see cref="RGCodeParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplication([NotNull] RGCodeParser.MultiplicationContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>singleFactor</c>
	/// labeled alternative in <see cref="RGCodeParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSingleFactor([NotNull] RGCodeParser.SingleFactorContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>power</c>
	/// labeled alternative in <see cref="RGCodeParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPower([NotNull] RGCodeParser.PowerContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>singeAtom</c>
	/// labeled alternative in <see cref="RGCodeParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSingeAtom([NotNull] RGCodeParser.SingeAtomContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>value</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] RGCodeParser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>idMath</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdMath([NotNull] RGCodeParser.IdMathContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>compund</c>
	/// labeled alternative in <see cref="RGCodeParser.atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompund([NotNull] RGCodeParser.CompundContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RGCodeParser.bool"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBool([NotNull] RGCodeParser.BoolContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>pointExpression</c>
	/// labeled alternative in <see cref="RGCodeParser.point"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPointExpression([NotNull] RGCodeParser.PointExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>idPoint</c>
	/// labeled alternative in <see cref="RGCodeParser.point"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdPoint([NotNull] RGCodeParser.IdPointContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RGCodeParser.move"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMove([NotNull] RGCodeParser.MoveContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RGCodeParser.line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLine([NotNull] RGCodeParser.LineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RGCodeParser.curve"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCurve([NotNull] RGCodeParser.CurveContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>to</c>
	/// labeled alternative in <see cref="RGCodeParser.toCommands"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTo([NotNull] RGCodeParser.ToContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RGCodeParser.repeat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRepeat([NotNull] RGCodeParser.RepeatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RGCodeParser.if"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIf([NotNull] RGCodeParser.IfContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="RGCodeParser.ifElse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfElse([NotNull] RGCodeParser.IfElseContext context);
}
