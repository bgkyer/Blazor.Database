﻿/// =================================
/// Author: Shaun Curtis, Cold Elm
/// License: MIT
/// ==================================

using System;

namespace Blazor.Database.Data
{
    public class Paginator
    {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 25;

        public int BlockSize { get; set; } = 10;

        public int RecordCount { get; set; } = 0;

        public Paginator(int pageSize, int blockSize)
        {
            this.BlockSize = blockSize;
            this.PageSize = pageSize;
        }

        public event EventHandler PageChanged;

        public int LastPage => (int)((RecordCount / PageSize) + 0.5);
        public int LastBlock => (int)((LastPage / BlockSize) + 1.5);
        public int CurrentBlock => (int)((Page / BlockSize) + 1.5);
        public int StartBlockPage => ((CurrentBlock - 1) * BlockSize) + 1;
        public int EndBlockPage => StartBlockPage + BlockSize;
        public bool HasBlocks => ((RecordCount / (PageSize * BlockSize))+ 0.5) > 1;
        public bool HasPagination => (RecordCount / PageSize) > 1;

        public void NextPage()
        {
            this.Page++;
            this.PageChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ToPage(int page)
        {
            if (this.Page != page)
            {
                this.Page = page;
                this.PageChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void PreviousPage()
        {
            this.Page++;
            this.PageChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ToStart()
        {
            this.Page = 1;
            this.PageChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ToEnd()
        {
            this.Page = (int)((RecordCount / PageSize) + 0.5);
            this.PageChanged?.Invoke(this, EventArgs.Empty);
        }

        public void NextBlock()
        {
            if (CurrentBlock != LastBlock)
            {
                var calcpage = (CurrentBlock * PageSize * BlockSize) + 1;
                this.Page = calcpage > LastPage ? LastPage : LastPage;
                this.PageChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void PreviousBlock()
        {
            if (CurrentBlock != 1)
            {
                this.Page = ((CurrentBlock - 2) * PageSize * BlockSize) + 1;
                this.PageChanged?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
