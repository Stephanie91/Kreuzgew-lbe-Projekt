﻿using KreuzgewoelbeCore.RoundedTriangles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangulationRefiner
{
    public abstract class FunctionEdge : Edge<VertexNormal>
    {
        public Vertex NextVertex { get { return _NextVertex.Value; } }

        /// <summary>
        /// sehr hilfreich, um die referenz zu behalten
        /// </summary>
        private Lazy<Vertex> _NextVertex;

        public FunctionEdge(VertexNormal start, VertexNormal end)
            : base(start, end)
        {
            _NextVertex = new Lazy<Vertex>(GetNextVertex);
        }

        protected abstract Vertex GetNextVertex();
    }
}