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

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.1")]
[System.CLSCompliant(false)]
public partial class RGCodeLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, BoolOperator=20, Typeword=21, BooleanValue=22, ScopeStart=23, 
		ScopeEnd=24, Mul_Div=25, Plus_Minus=26, WS=27, Number=28, ID=29, COMMENT=30;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "BoolOperator", "Typeword", "BooleanValue", "ScopeStart", 
		"ScopeEnd", "Mul_Div", "Plus_Minus", "WS", "Number", "ID", "COMMENT"
	};


	public RGCodeLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public RGCodeLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "';'", "'='", "'+'", "'-'", "'*'", "'/'", "'^'", "'('", "')'", "','", 
		"'line from'", "'curve from'", "'with angle'", "'to '", "'repeat'", "'until'", 
		"'iff'", "'then'", "'else do'", null, null, null, "'begin'", "'end'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, "BoolOperator", "Typeword", 
		"BooleanValue", "ScopeStart", "ScopeEnd", "Mul_Div", "Plus_Minus", "WS", 
		"Number", "ID", "COMMENT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "RGCode.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static RGCodeLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', ' ', '\x111', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x3', 
		'\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', 
		'\x3', '\n', '\x3', '\n', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', 
		'\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', 
		'\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', 
		'\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', 
		'\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', '\x3', 
		'\xF', '\x3', '\xF', '\x3', '\xF', '\x3', '\x10', '\x3', '\x10', '\x3', 
		'\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', '\x10', '\x3', 
		'\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', '\x11', '\x3', 
		'\x11', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', '\x12', '\x3', 
		'\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', 
		'\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', 
		'\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', 
		'\x15', '\x5', '\x15', '\x99', '\n', '\x15', '\x3', '\x16', '\x3', '\x16', 
		'\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', 
		'\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', 
		'\x3', '\x16', '\x3', '\x16', '\x5', '\x16', '\xA9', '\n', '\x16', '\x3', 
		'\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', 
		'\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x5', '\x17', '\xB4', 
		'\n', '\x17', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', '\x3', '\x18', 
		'\x3', '\x18', '\x3', '\x18', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', 
		'\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', '\x3', '\x1B', '\x3', '\x1B', 
		'\x3', '\x1C', '\x6', '\x1C', '\xC5', '\n', '\x1C', '\r', '\x1C', '\xE', 
		'\x1C', '\xC6', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x6', '\x1D', 
		'\xCC', '\n', '\x1D', '\r', '\x1D', '\xE', '\x1D', '\xCD', '\x3', '\x1D', 
		'\x3', '\x1D', '\x6', '\x1D', '\xD2', '\n', '\x1D', '\r', '\x1D', '\xE', 
		'\x1D', '\xD3', '\x5', '\x1D', '\xD6', '\n', '\x1D', '\x3', '\x1D', '\x6', 
		'\x1D', '\xD9', '\n', '\x1D', '\r', '\x1D', '\xE', '\x1D', '\xDA', '\x3', 
		'\x1D', '\x3', '\x1D', '\x6', '\x1D', '\xDF', '\n', '\x1D', '\r', '\x1D', 
		'\xE', '\x1D', '\xE0', '\x3', '\x1D', '\x3', '\x1D', '\x6', '\x1D', '\xE5', 
		'\n', '\x1D', '\r', '\x1D', '\xE', '\x1D', '\xE6', '\x3', '\x1D', '\x3', 
		'\x1D', '\x6', '\x1D', '\xEB', '\n', '\x1D', '\r', '\x1D', '\xE', '\x1D', 
		'\xEC', '\x3', '\x1D', '\x3', '\x1D', '\x6', '\x1D', '\xF1', '\n', '\x1D', 
		'\r', '\x1D', '\xE', '\x1D', '\xF2', '\x5', '\x1D', '\xF5', '\n', '\x1D', 
		'\x5', '\x1D', '\xF7', '\n', '\x1D', '\x3', '\x1E', '\x6', '\x1E', '\xFA', 
		'\n', '\x1E', '\r', '\x1E', '\xE', '\x1E', '\xFB', '\x3', '\x1E', '\a', 
		'\x1E', '\xFF', '\n', '\x1E', '\f', '\x1E', '\xE', '\x1E', '\x102', '\v', 
		'\x1E', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\a', 
		'\x1F', '\x108', '\n', '\x1F', '\f', '\x1F', '\xE', '\x1F', '\x10B', '\v', 
		'\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', 
		'\x1F', '\x3', '\x109', '\x2', ' ', '\x3', '\x3', '\x5', '\x4', '\a', 
		'\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', 
		'\x13', '\v', '\x15', '\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', 
		'\x1D', '\x10', '\x1F', '\x11', '!', '\x12', '#', '\x13', '%', '\x14', 
		'\'', '\x15', ')', '\x16', '+', '\x17', '-', '\x18', '/', '\x19', '\x31', 
		'\x1A', '\x33', '\x1B', '\x35', '\x1C', '\x37', '\x1D', '\x39', '\x1E', 
		';', '\x1F', '=', ' ', '\x3', '\x2', '\t', '\x4', '\x2', '>', '>', '@', 
		'@', '\x4', '\x2', ',', ',', '\x31', '\x31', '\x4', '\x2', '-', '-', '/', 
		'/', '\x5', '\x2', '\v', '\f', '\xF', '\xF', '\"', '\"', '\x3', '\x2', 
		'\x32', ';', '\x4', '\x2', '\x43', '\\', '\x63', '|', '\x5', '\x2', '\x32', 
		';', '\x43', '\\', '\x63', '|', '\x2', '\x123', '\x2', '\x3', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\xF', '\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x19', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\'', '\x3', '\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '+', '\x3', '\x2', '\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '/', '\x3', '\x2', '\x2', '\x2', '\x2', '\x31', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x33', '\x3', '\x2', '\x2', '\x2', '\x2', '\x35', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x37', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x39', '\x3', '\x2', '\x2', '\x2', '\x2', ';', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '=', '\x3', '\x2', '\x2', '\x2', '\x3', '?', '\x3', '\x2', 
		'\x2', '\x2', '\x5', '\x41', '\x3', '\x2', '\x2', '\x2', '\a', '\x43', 
		'\x3', '\x2', '\x2', '\x2', '\t', '\x45', '\x3', '\x2', '\x2', '\x2', 
		'\v', 'G', '\x3', '\x2', '\x2', '\x2', '\r', 'I', '\x3', '\x2', '\x2', 
		'\x2', '\xF', 'K', '\x3', '\x2', '\x2', '\x2', '\x11', 'M', '\x3', '\x2', 
		'\x2', '\x2', '\x13', 'O', '\x3', '\x2', '\x2', '\x2', '\x15', 'Q', '\x3', 
		'\x2', '\x2', '\x2', '\x17', 'S', '\x3', '\x2', '\x2', '\x2', '\x19', 
		']', '\x3', '\x2', '\x2', '\x2', '\x1B', 'h', '\x3', '\x2', '\x2', '\x2', 
		'\x1D', 's', '\x3', '\x2', '\x2', '\x2', '\x1F', 'w', '\x3', '\x2', '\x2', 
		'\x2', '!', '~', '\x3', '\x2', '\x2', '\x2', '#', '\x84', '\x3', '\x2', 
		'\x2', '\x2', '%', '\x88', '\x3', '\x2', '\x2', '\x2', '\'', '\x8D', '\x3', 
		'\x2', '\x2', '\x2', ')', '\x98', '\x3', '\x2', '\x2', '\x2', '+', '\xA8', 
		'\x3', '\x2', '\x2', '\x2', '-', '\xB3', '\x3', '\x2', '\x2', '\x2', '/', 
		'\xB5', '\x3', '\x2', '\x2', '\x2', '\x31', '\xBB', '\x3', '\x2', '\x2', 
		'\x2', '\x33', '\xBF', '\x3', '\x2', '\x2', '\x2', '\x35', '\xC1', '\x3', 
		'\x2', '\x2', '\x2', '\x37', '\xC4', '\x3', '\x2', '\x2', '\x2', '\x39', 
		'\xF6', '\x3', '\x2', '\x2', '\x2', ';', '\xF9', '\x3', '\x2', '\x2', 
		'\x2', '=', '\x103', '\x3', '\x2', '\x2', '\x2', '?', '@', '\a', '=', 
		'\x2', '\x2', '@', '\x4', '\x3', '\x2', '\x2', '\x2', '\x41', '\x42', 
		'\a', '?', '\x2', '\x2', '\x42', '\x6', '\x3', '\x2', '\x2', '\x2', '\x43', 
		'\x44', '\a', '-', '\x2', '\x2', '\x44', '\b', '\x3', '\x2', '\x2', '\x2', 
		'\x45', '\x46', '\a', '/', '\x2', '\x2', '\x46', '\n', '\x3', '\x2', '\x2', 
		'\x2', 'G', 'H', '\a', ',', '\x2', '\x2', 'H', '\f', '\x3', '\x2', '\x2', 
		'\x2', 'I', 'J', '\a', '\x31', '\x2', '\x2', 'J', '\xE', '\x3', '\x2', 
		'\x2', '\x2', 'K', 'L', '\a', '`', '\x2', '\x2', 'L', '\x10', '\x3', '\x2', 
		'\x2', '\x2', 'M', 'N', '\a', '*', '\x2', '\x2', 'N', '\x12', '\x3', '\x2', 
		'\x2', '\x2', 'O', 'P', '\a', '+', '\x2', '\x2', 'P', '\x14', '\x3', '\x2', 
		'\x2', '\x2', 'Q', 'R', '\a', '.', '\x2', '\x2', 'R', '\x16', '\x3', '\x2', 
		'\x2', '\x2', 'S', 'T', '\a', 'n', '\x2', '\x2', 'T', 'U', '\a', 'k', 
		'\x2', '\x2', 'U', 'V', '\a', 'p', '\x2', '\x2', 'V', 'W', '\a', 'g', 
		'\x2', '\x2', 'W', 'X', '\a', '\"', '\x2', '\x2', 'X', 'Y', '\a', 'h', 
		'\x2', '\x2', 'Y', 'Z', '\a', 't', '\x2', '\x2', 'Z', '[', '\a', 'q', 
		'\x2', '\x2', '[', '\\', '\a', 'o', '\x2', '\x2', '\\', '\x18', '\x3', 
		'\x2', '\x2', '\x2', ']', '^', '\a', '\x65', '\x2', '\x2', '^', '_', '\a', 
		'w', '\x2', '\x2', '_', '`', '\a', 't', '\x2', '\x2', '`', '\x61', '\a', 
		'x', '\x2', '\x2', '\x61', '\x62', '\a', 'g', '\x2', '\x2', '\x62', '\x63', 
		'\a', '\"', '\x2', '\x2', '\x63', '\x64', '\a', 'h', '\x2', '\x2', '\x64', 
		'\x65', '\a', 't', '\x2', '\x2', '\x65', '\x66', '\a', 'q', '\x2', '\x2', 
		'\x66', 'g', '\a', 'o', '\x2', '\x2', 'g', '\x1A', '\x3', '\x2', '\x2', 
		'\x2', 'h', 'i', '\a', 'y', '\x2', '\x2', 'i', 'j', '\a', 'k', '\x2', 
		'\x2', 'j', 'k', '\a', 'v', '\x2', '\x2', 'k', 'l', '\a', 'j', '\x2', 
		'\x2', 'l', 'm', '\a', '\"', '\x2', '\x2', 'm', 'n', '\a', '\x63', '\x2', 
		'\x2', 'n', 'o', '\a', 'p', '\x2', '\x2', 'o', 'p', '\a', 'i', '\x2', 
		'\x2', 'p', 'q', '\a', 'n', '\x2', '\x2', 'q', 'r', '\a', 'g', '\x2', 
		'\x2', 'r', '\x1C', '\x3', '\x2', '\x2', '\x2', 's', 't', '\a', 'v', '\x2', 
		'\x2', 't', 'u', '\a', 'q', '\x2', '\x2', 'u', 'v', '\a', '\"', '\x2', 
		'\x2', 'v', '\x1E', '\x3', '\x2', '\x2', '\x2', 'w', 'x', '\a', 't', '\x2', 
		'\x2', 'x', 'y', '\a', 'g', '\x2', '\x2', 'y', 'z', '\a', 'r', '\x2', 
		'\x2', 'z', '{', '\a', 'g', '\x2', '\x2', '{', '|', '\a', '\x63', '\x2', 
		'\x2', '|', '}', '\a', 'v', '\x2', '\x2', '}', ' ', '\x3', '\x2', '\x2', 
		'\x2', '~', '\x7F', '\a', 'w', '\x2', '\x2', '\x7F', '\x80', '\a', 'p', 
		'\x2', '\x2', '\x80', '\x81', '\a', 'v', '\x2', '\x2', '\x81', '\x82', 
		'\a', 'k', '\x2', '\x2', '\x82', '\x83', '\a', 'n', '\x2', '\x2', '\x83', 
		'\"', '\x3', '\x2', '\x2', '\x2', '\x84', '\x85', '\a', 'k', '\x2', '\x2', 
		'\x85', '\x86', '\a', 'h', '\x2', '\x2', '\x86', '\x87', '\a', 'h', '\x2', 
		'\x2', '\x87', '$', '\x3', '\x2', '\x2', '\x2', '\x88', '\x89', '\a', 
		'v', '\x2', '\x2', '\x89', '\x8A', '\a', 'j', '\x2', '\x2', '\x8A', '\x8B', 
		'\a', 'g', '\x2', '\x2', '\x8B', '\x8C', '\a', 'p', '\x2', '\x2', '\x8C', 
		'&', '\x3', '\x2', '\x2', '\x2', '\x8D', '\x8E', '\a', 'g', '\x2', '\x2', 
		'\x8E', '\x8F', '\a', 'n', '\x2', '\x2', '\x8F', '\x90', '\a', 'u', '\x2', 
		'\x2', '\x90', '\x91', '\a', 'g', '\x2', '\x2', '\x91', '\x92', '\a', 
		'\"', '\x2', '\x2', '\x92', '\x93', '\a', '\x66', '\x2', '\x2', '\x93', 
		'\x94', '\a', 'q', '\x2', '\x2', '\x94', '(', '\x3', '\x2', '\x2', '\x2', 
		'\x95', '\x99', '\t', '\x2', '\x2', '\x2', '\x96', '\x97', '\a', '?', 
		'\x2', '\x2', '\x97', '\x99', '\a', '?', '\x2', '\x2', '\x98', '\x95', 
		'\x3', '\x2', '\x2', '\x2', '\x98', '\x96', '\x3', '\x2', '\x2', '\x2', 
		'\x99', '*', '\x3', '\x2', '\x2', '\x2', '\x9A', '\x9B', '\a', 'p', '\x2', 
		'\x2', '\x9B', '\x9C', '\a', 'w', '\x2', '\x2', '\x9C', '\x9D', '\a', 
		'o', '\x2', '\x2', '\x9D', '\x9E', '\a', '\x64', '\x2', '\x2', '\x9E', 
		'\x9F', '\a', 'g', '\x2', '\x2', '\x9F', '\xA9', '\a', 't', '\x2', '\x2', 
		'\xA0', '\xA1', '\a', 'k', '\x2', '\x2', '\xA1', '\xA2', '\a', 'p', '\x2', 
		'\x2', '\xA2', '\xA9', '\a', 'v', '\x2', '\x2', '\xA3', '\xA4', '\a', 
		'r', '\x2', '\x2', '\xA4', '\xA5', '\a', 'q', '\x2', '\x2', '\xA5', '\xA6', 
		'\a', 'k', '\x2', '\x2', '\xA6', '\xA7', '\a', 'p', '\x2', '\x2', '\xA7', 
		'\xA9', '\a', 'v', '\x2', '\x2', '\xA8', '\x9A', '\x3', '\x2', '\x2', 
		'\x2', '\xA8', '\xA0', '\x3', '\x2', '\x2', '\x2', '\xA8', '\xA3', '\x3', 
		'\x2', '\x2', '\x2', '\xA9', ',', '\x3', '\x2', '\x2', '\x2', '\xAA', 
		'\xAB', '\a', 'v', '\x2', '\x2', '\xAB', '\xAC', '\a', 't', '\x2', '\x2', 
		'\xAC', '\xAD', '\a', 'w', '\x2', '\x2', '\xAD', '\xB4', '\a', 'g', '\x2', 
		'\x2', '\xAE', '\xAF', '\a', 'h', '\x2', '\x2', '\xAF', '\xB0', '\a', 
		'\x63', '\x2', '\x2', '\xB0', '\xB1', '\a', 'n', '\x2', '\x2', '\xB1', 
		'\xB2', '\a', 'u', '\x2', '\x2', '\xB2', '\xB4', '\a', 'g', '\x2', '\x2', 
		'\xB3', '\xAA', '\x3', '\x2', '\x2', '\x2', '\xB3', '\xAE', '\x3', '\x2', 
		'\x2', '\x2', '\xB4', '.', '\x3', '\x2', '\x2', '\x2', '\xB5', '\xB6', 
		'\a', '\x64', '\x2', '\x2', '\xB6', '\xB7', '\a', 'g', '\x2', '\x2', '\xB7', 
		'\xB8', '\a', 'i', '\x2', '\x2', '\xB8', '\xB9', '\a', 'k', '\x2', '\x2', 
		'\xB9', '\xBA', '\a', 'p', '\x2', '\x2', '\xBA', '\x30', '\x3', '\x2', 
		'\x2', '\x2', '\xBB', '\xBC', '\a', 'g', '\x2', '\x2', '\xBC', '\xBD', 
		'\a', 'p', '\x2', '\x2', '\xBD', '\xBE', '\a', '\x66', '\x2', '\x2', '\xBE', 
		'\x32', '\x3', '\x2', '\x2', '\x2', '\xBF', '\xC0', '\t', '\x3', '\x2', 
		'\x2', '\xC0', '\x34', '\x3', '\x2', '\x2', '\x2', '\xC1', '\xC2', '\t', 
		'\x4', '\x2', '\x2', '\xC2', '\x36', '\x3', '\x2', '\x2', '\x2', '\xC3', 
		'\xC5', '\t', '\x5', '\x2', '\x2', '\xC4', '\xC3', '\x3', '\x2', '\x2', 
		'\x2', '\xC5', '\xC6', '\x3', '\x2', '\x2', '\x2', '\xC6', '\xC4', '\x3', 
		'\x2', '\x2', '\x2', '\xC6', '\xC7', '\x3', '\x2', '\x2', '\x2', '\xC7', 
		'\xC8', '\x3', '\x2', '\x2', '\x2', '\xC8', '\xC9', '\b', '\x1C', '\x2', 
		'\x2', '\xC9', '\x38', '\x3', '\x2', '\x2', '\x2', '\xCA', '\xCC', '\t', 
		'\x6', '\x2', '\x2', '\xCB', '\xCA', '\x3', '\x2', '\x2', '\x2', '\xCC', 
		'\xCD', '\x3', '\x2', '\x2', '\x2', '\xCD', '\xCB', '\x3', '\x2', '\x2', 
		'\x2', '\xCD', '\xCE', '\x3', '\x2', '\x2', '\x2', '\xCE', '\xD6', '\x3', 
		'\x2', '\x2', '\x2', '\xCF', '\xD1', '\a', '/', '\x2', '\x2', '\xD0', 
		'\xD2', '\t', '\x6', '\x2', '\x2', '\xD1', '\xD0', '\x3', '\x2', '\x2', 
		'\x2', '\xD2', '\xD3', '\x3', '\x2', '\x2', '\x2', '\xD3', '\xD1', '\x3', 
		'\x2', '\x2', '\x2', '\xD3', '\xD4', '\x3', '\x2', '\x2', '\x2', '\xD4', 
		'\xD6', '\x3', '\x2', '\x2', '\x2', '\xD5', '\xCB', '\x3', '\x2', '\x2', 
		'\x2', '\xD5', '\xCF', '\x3', '\x2', '\x2', '\x2', '\xD6', '\xF7', '\x3', 
		'\x2', '\x2', '\x2', '\xD7', '\xD9', '\t', '\x6', '\x2', '\x2', '\xD8', 
		'\xD7', '\x3', '\x2', '\x2', '\x2', '\xD9', '\xDA', '\x3', '\x2', '\x2', 
		'\x2', '\xDA', '\xD8', '\x3', '\x2', '\x2', '\x2', '\xDA', '\xDB', '\x3', 
		'\x2', '\x2', '\x2', '\xDB', '\xDC', '\x3', '\x2', '\x2', '\x2', '\xDC', 
		'\xDE', '\a', '\x30', '\x2', '\x2', '\xDD', '\xDF', '\t', '\x6', '\x2', 
		'\x2', '\xDE', '\xDD', '\x3', '\x2', '\x2', '\x2', '\xDF', '\xE0', '\x3', 
		'\x2', '\x2', '\x2', '\xE0', '\xDE', '\x3', '\x2', '\x2', '\x2', '\xE0', 
		'\xE1', '\x3', '\x2', '\x2', '\x2', '\xE1', '\xF5', '\x3', '\x2', '\x2', 
		'\x2', '\xE2', '\xE4', '\a', '/', '\x2', '\x2', '\xE3', '\xE5', '\t', 
		'\x6', '\x2', '\x2', '\xE4', '\xE3', '\x3', '\x2', '\x2', '\x2', '\xE5', 
		'\xE6', '\x3', '\x2', '\x2', '\x2', '\xE6', '\xE4', '\x3', '\x2', '\x2', 
		'\x2', '\xE6', '\xE7', '\x3', '\x2', '\x2', '\x2', '\xE7', '\xF5', '\x3', 
		'\x2', '\x2', '\x2', '\xE8', '\xEA', '\a', '/', '\x2', '\x2', '\xE9', 
		'\xEB', '\t', '\x6', '\x2', '\x2', '\xEA', '\xE9', '\x3', '\x2', '\x2', 
		'\x2', '\xEB', '\xEC', '\x3', '\x2', '\x2', '\x2', '\xEC', '\xEA', '\x3', 
		'\x2', '\x2', '\x2', '\xEC', '\xED', '\x3', '\x2', '\x2', '\x2', '\xED', 
		'\xEE', '\x3', '\x2', '\x2', '\x2', '\xEE', '\xF0', '\a', '\x30', '\x2', 
		'\x2', '\xEF', '\xF1', '\t', '\x6', '\x2', '\x2', '\xF0', '\xEF', '\x3', 
		'\x2', '\x2', '\x2', '\xF1', '\xF2', '\x3', '\x2', '\x2', '\x2', '\xF2', 
		'\xF0', '\x3', '\x2', '\x2', '\x2', '\xF2', '\xF3', '\x3', '\x2', '\x2', 
		'\x2', '\xF3', '\xF5', '\x3', '\x2', '\x2', '\x2', '\xF4', '\xD8', '\x3', 
		'\x2', '\x2', '\x2', '\xF4', '\xE2', '\x3', '\x2', '\x2', '\x2', '\xF4', 
		'\xE8', '\x3', '\x2', '\x2', '\x2', '\xF5', '\xF7', '\x3', '\x2', '\x2', 
		'\x2', '\xF6', '\xD5', '\x3', '\x2', '\x2', '\x2', '\xF6', '\xF4', '\x3', 
		'\x2', '\x2', '\x2', '\xF7', ':', '\x3', '\x2', '\x2', '\x2', '\xF8', 
		'\xFA', '\t', '\a', '\x2', '\x2', '\xF9', '\xF8', '\x3', '\x2', '\x2', 
		'\x2', '\xFA', '\xFB', '\x3', '\x2', '\x2', '\x2', '\xFB', '\xF9', '\x3', 
		'\x2', '\x2', '\x2', '\xFB', '\xFC', '\x3', '\x2', '\x2', '\x2', '\xFC', 
		'\x100', '\x3', '\x2', '\x2', '\x2', '\xFD', '\xFF', '\t', '\b', '\x2', 
		'\x2', '\xFE', '\xFD', '\x3', '\x2', '\x2', '\x2', '\xFF', '\x102', '\x3', 
		'\x2', '\x2', '\x2', '\x100', '\xFE', '\x3', '\x2', '\x2', '\x2', '\x100', 
		'\x101', '\x3', '\x2', '\x2', '\x2', '\x101', '<', '\x3', '\x2', '\x2', 
		'\x2', '\x102', '\x100', '\x3', '\x2', '\x2', '\x2', '\x103', '\x104', 
		'\a', '\x31', '\x2', '\x2', '\x104', '\x105', '\a', ',', '\x2', '\x2', 
		'\x105', '\x109', '\x3', '\x2', '\x2', '\x2', '\x106', '\x108', '\v', 
		'\x2', '\x2', '\x2', '\x107', '\x106', '\x3', '\x2', '\x2', '\x2', '\x108', 
		'\x10B', '\x3', '\x2', '\x2', '\x2', '\x109', '\x10A', '\x3', '\x2', '\x2', 
		'\x2', '\x109', '\x107', '\x3', '\x2', '\x2', '\x2', '\x10A', '\x10C', 
		'\x3', '\x2', '\x2', '\x2', '\x10B', '\x109', '\x3', '\x2', '\x2', '\x2', 
		'\x10C', '\x10D', '\a', ',', '\x2', '\x2', '\x10D', '\x10E', '\a', '\x31', 
		'\x2', '\x2', '\x10E', '\x10F', '\x3', '\x2', '\x2', '\x2', '\x10F', '\x110', 
		'\b', '\x1F', '\x2', '\x2', '\x110', '>', '\x3', '\x2', '\x2', '\x2', 
		'\x14', '\x2', '\x98', '\xA8', '\xB3', '\xC6', '\xCD', '\xD3', '\xD5', 
		'\xDA', '\xE0', '\xE6', '\xEC', '\xF2', '\xF4', '\xF6', '\xFB', '\x100', 
		'\x109', '\x3', '\b', '\x2', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}